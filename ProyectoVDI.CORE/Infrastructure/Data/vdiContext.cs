using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;

namespace ProyectoVDI.CORE.Infrastructure.Data;

public partial class vdiContext : DbContext
{
    public vdiContext()
    {
    }

    public vdiContext(DbContextOptions<vdiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autoria> Autoria { get; set; }

    public virtual DbSet<CalificacionChatBot> CalificacionChatBot { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<DetRegistroIssn> DetRegistroIssn { get; set; }

    public virtual DbSet<Evaluaciones> Evaluaciones { get; set; }

    public virtual DbSet<PreguntasFrecuentesChatBot> PreguntasFrecuentesChatBot { get; set; }

    public virtual DbSet<PresenciaEnListas> PresenciaEnListas { get; set; }

    public virtual DbSet<Profesores> Profesores { get; set; }

    public virtual DbSet<RegistroIssn> RegistroIssn { get; set; }

    public virtual DbSet<Revista> Revista { get; set; }

    public virtual DbSet<RevistaIndexacion> RevistaIndexacion { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autoria>(entity =>
        {
            entity.HasKey(e => e.IdAutoria).HasName("PK__Autoria__C35BB0A7E5F73E1C");

            entity.Property(e => e.IdAutoria).HasColumnName("Id_autoria");
            entity.Property(e => e.CoautoriaEsan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Coautoria ESAN");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.PosiciónDelAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Posición del autor");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.Autoria)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__Autoria__Id_revi__5812160E");
        });

        modelBuilder.Entity<CalificacionChatBot>(entity =>
        {
            entity.HasKey(e => e.IdFeedback).HasName("PK__Califica__3DA0483FFD1958C9");

            entity.Property(e => e.IdFeedback).HasColumnName("Id_Feedback");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CalificacionChatBot)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Calificac__idUsu__44FF419A");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C82A31BBE");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetRegistroIssn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DetRegistroISSN");

            entity.Property(e => e.IdRegistroIssn).HasColumnName("Id_RegistroISSN");
            entity.Property(e => e.IdRevista).HasColumnName("Id_Revista");
            entity.Property(e => e.TipoRevista)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRegistroIssnNavigation).WithMany()
                .HasForeignKey(d => d.IdRegistroIssn)
                .HasConstraintName("FK__DetRegist__Id_Re__4CA06362");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany()
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__DetRegist__Id_Re__4D94879B");
        });

        modelBuilder.Entity<Evaluaciones>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PK__Evaluaci__D30A2CE398640F34");

            entity.HasIndex(e => e.IdRevista, "UQ__Evaluaci__3F68F3B38C800056").IsUnique();

            entity.Property(e => e.IdEvaluacion).HasColumnName("Id_evaluacion");
            entity.Property(e => e.Abdc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABDC");
            entity.Property(e => e.AbdcExiste).HasColumnName("ABDC Existe");
            entity.Property(e => e.AbdcS).HasColumnName("ABDC (S)");
            entity.Property(e => e.Ajg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.Ajg4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG=4*");
            entity.Property(e => e.AjgExiste).HasColumnName("AJG Existe");
            entity.Property(e => e.AjgS).HasColumnName("AJG (S)");
            entity.Property(e => e.Cnrs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.CnrsExiste).HasColumnName("CNRS Existe");
            entity.Property(e => e.CnrsS).HasColumnName("CNRS (S)");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");

            entity.HasOne(d => d.IdRevistaNavigation).WithOne(p => p.Evaluaciones)
                .HasForeignKey<Evaluaciones>(d => d.IdRevista)
                .HasConstraintName("FK__Evaluacio__Id_re__5165187F");
        });

        modelBuilder.Entity<PreguntasFrecuentesChatBot>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__1298DD2DA36409AD");

            entity.Property(e => e.IdPregunta).HasColumnName("Id_Pregunta");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PreguntasFrecuentesChatBot)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Preguntas__idUsu__4222D4EF");
        });

        modelBuilder.Entity<PresenciaEnListas>(entity =>
        {
            entity.HasKey(e => e.IdLista).HasName("PK__Presenci__CFBAEE5336E42582");

            entity.HasIndex(e => e.IdRevista, "UQ__Presenci__3F68F3B34C46ABE7").IsUnique();

            entity.Property(e => e.IdLista).HasColumnName("Id_lista");
            entity.Property(e => e.AlMenosEnUnaLista)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Al menos en una lista");
            entity.Property(e => e.BeallSList)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("BEALL'S LIST");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.Insights)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("INSIGHTS");
            entity.Property(e => e.Mdpi)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MDPI");
            entity.Property(e => e.MultyYAlMenosUnaLista).HasColumnName("Multy y al menos una lista");
            entity.Property(e => e.SoloEnUnaLista)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Solo en una lista");
            entity.Property(e => e.Top50)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TOP50");
            entity.Property(e => e._216bEspecial).HasColumnName("2.1.6B especial");

            entity.HasOne(d => d.IdRevistaNavigation).WithOne(p => p.PresenciaEnListas)
                .HasForeignKey<PresenciaEnListas>(d => d.IdRevista)
                .HasConstraintName("FK__Presencia__Id_re__5535A963");
        });

        modelBuilder.Entity<Profesores>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__45D4152ADF45EB81");

            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.NombreyApellido)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Profesore__IdCat__3F466844");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Profesore__IdUsu__3E52440B");
        });

        modelBuilder.Entity<RegistroIssn>(entity =>
        {
            entity.HasKey(e => e.IdRegistroIssn).HasName("PK__Registro__B0A8C7174A859B81");

            entity.ToTable("RegistroISSN");

            entity.Property(e => e.IdRegistroIssn).HasColumnName("Id_RegistroISSN");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistroIssn)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__RegistroI__Id_Us__47DBAE45");
        });

        modelBuilder.Entity<Revista>(entity =>
        {
            entity.HasKey(e => e.IdRevista).HasName("PK__Revista__3F68F3B28FF6C71A");

            entity.HasIndex(e => e.Issn, "UQ__Revista__447D3E9661F71D4D").IsUnique();

            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Issn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ISSN");
            entity.Property(e => e.Jif).HasColumnName("JIF");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RevistaIndexacion>(entity =>
        {
            entity.HasKey(e => e.IdIndexacion).HasName("PK__RevistaI__A651221282F49B7F");

            entity.HasIndex(e => e.IdRevista, "UQ__RevistaI__3F68F3B3BCD8900B").IsUnique();

            entity.Property(e => e.IdIndexacion).HasColumnName("Id_indexacion");
            entity.Property(e => e.EsciQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESCI Q");
            entity.Property(e => e.EsciScieloSinScupus).HasColumnName("ESCI/scielo sin Scupus");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.LatamSinEsciExiste).HasColumnName("Latam sin ESCI Existe");
            entity.Property(e => e.MultidisciplinaryScopus).HasColumnName("Multidisciplinary SCOPUS");
            entity.Property(e => e.MultidisciplinaryWos).HasColumnName("Multidisciplinary WOS");
            entity.Property(e => e.MultidisciplinaryWosOScopys).HasColumnName("Multidisciplinary WOS O SCOPYS");
            entity.Property(e => e.Scielo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Scopus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SCOPUS");
            entity.Property(e => e.ScopusExiste).HasColumnName("Scopus Existe");
            entity.Property(e => e.SoloScieloExiste).HasColumnName("Solo Scielo Existe");
            entity.Property(e => e.WoSEsci)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("WoS ESCi");
            entity.Property(e => e.WoSEsciExiste).HasColumnName("WoS ESCI Existe");
            entity.Property(e => e.WoSLatam)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("WoS LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("WoS (Q)");
            entity.Property(e => e.WoSS).HasColumnName("WoS (S)");
            entity.Property(e => e.WoSTopExiste).HasColumnName("WoS top Existe");

            entity.HasOne(d => d.IdRevistaNavigation).WithOne(p => p.RevistaIndexacion)
                .HasForeignKey<RevistaIndexacion>(d => d.IdRevista)
                .HasConstraintName("FK__RevistaIn__Id_re__5BE2A6F2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E860A6040E1");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A660CDAB3C");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__Id_Rol__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
