using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;
using ProyectoVDI.CORE.Core.Interfaces;
using ProyectoVDI.CORE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVDI.CORE.Infrastructure.Repositories
{
    internal class UsuariosRepository : IUsuariosRepository
    {
        private readonly vdiContext _context;
        public UsuariosRepository(vdiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await GetUsuarioById(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
