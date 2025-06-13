using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.DTOs;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    // =====================
    // Repositorio para la gestión de usuarios
    // =====================
    public class UsuariosRepository : IUsuariosRepository
    {
        // Contexto de base de datos inyectado
        private readonly vdiContext _context;

        // Constructor
        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }

        // =====================
        // Obtiene todos los usuarios (sin filtrar por Estado)
        // =====================
        public async Task<List<Usuario>> GetAllAsync()
        {
            // Incluye la navegación a ProfesoresAdmis para poder acceder a NombreyApellido
            return await _context.Usuario.Include(u => u.IdProfesorAdmisNavigation).ToListAsync();
        }

        // =====================
        // Obtiene un usuario por su ID (sin filtrar por Estado)
        // =====================
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuario
                .Where(u => u.IdUsuario == id)
                .FirstOrDefaultAsync();
        }

        // =====================
        // Crea un nuevo usuario
        // =====================
        public async Task<int> CreateAsync(Usuario usuario)
        {
            usuario.Estado = 1;
            usuario.FechaCreacion = System.DateTime.Now;
            usuario.FechaModificacion = null;
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.IdUsuario;
        }

        // =====================
        // Actualiza un usuario existente
        // =====================
        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuario.FindAsync(usuario.IdUsuario);
            if (existingUsuario == null)
            {
                throw new System.InvalidOperationException($"No se encontró el usuario con ID {usuario.IdUsuario} para actualizar.");
            }
            existingUsuario.IdProfesorAdmis = usuario.IdProfesorAdmis;
            existingUsuario.Correo = usuario.Correo;
            existingUsuario.Contraseña = usuario.Contraseña;
            existingUsuario.IdRol = usuario.IdRol;
            // Estado ya no se actualiza desde el servicio
            existingUsuario.FechaModificacion = System.DateTime.Now;
            _context.Usuario.Update(existingUsuario);
            await _context.SaveChangesAsync();
        }

        // =====================
        // Elimina (soft delete) un usuario por su ID
        // =====================
        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new System.InvalidOperationException($"No se encontró el usuario con ID {id} para eliminar.");
            }
            usuario.Estado = 0; // Soft delete
            usuario.FechaModificacion = System.DateTime.Now;
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UsuarioReporteDTO>> GetUsuariosReporteAsync(UsuarioReporteFiltroDTO filtro)
        {
            var query = _context.Usuario
                .Include(u => u.IdProfesorAdmisNavigation)
                .Include(u => u.IdRolNavigation)
                .AsQueryable();

            if (filtro.IdRol.HasValue)
                query = query.Where(u => u.IdRol == filtro.IdRol);

            if (filtro.Estado.HasValue)
                query = query.Where(u => u.Estado == filtro.Estado);

            if (filtro.FechaInicio.HasValue)
                query = query.Where(u => u.FechaCreacion >= filtro.FechaInicio);

            if (filtro.FechaFin.HasValue)
                query = query.Where(u => u.FechaCreacion <= filtro.FechaFin);

            return await query.Select(u => new UsuarioReporteDTO
            {
                Correo = u.Correo,
                Descripcion = u.IdRolNavigation.Descripcion,
                DNI = u.IdProfesorAdmisNavigation.Dni,
                Estado = u.Estado,
                FechaCreacion = u.FechaCreacion,
                FechaModificacion = u.FechaModificacion
            }).ToListAsync();
        }
    }
}