using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoVDI.CORE.Core.Entities;


namespace ProyectoVDI.Infrastructure.Data;
public partial class vdiContext : DbContext
{
    public vdiContext()
    {
    }

    public vdiContext(DbContextOptions<vdiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalificacionChatBot> CalificacionChatBot { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<DetRegistroRevista> DetRegistroRevista { get; set; }

    public virtual DbSet<IssnsRevista> IssnsRevista { get; set; }

    public virtual DbSet<MetadatosRevistaIssn> MetadatosRevistaIssn { get; set; }

    public virtual DbSet<PreguntasFrecuentesChatBot> PreguntasFrecuentesChatBot { get; set; }

    public virtual DbSet<ProfesoresAdmis> ProfesoresAdmis { get; set; }

    public virtual DbSet<RegistroRevistas> RegistroRevistas { get; set; }

    public virtual DbSet<Revista> Revista { get; set; }

    public virtual DbSet<RevistaListaCerrada> RevistaListaCerrada { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalificacionChatBot>(entity =>
        {
            entity.HasKey(e => e.IdFeedback).HasName("PK__Califica__3DA0483F42F3221E");

            entity.Property(e => e.IdFeedback).HasColumnName("Id_Feedback");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CalificacionChatBot)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Calificac__idUsu__44FF419A");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CE0C7BB38");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetRegistroRevista>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetRegis__9274780B3A4B5462");

            entity.Property(e => e.IdDetalle).HasColumnName("Id_Detalle");
            entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");
            entity.Property(e => e.IdRevista).HasColumnName("Id_Revista");

            entity.HasOne(d => d.IdRegistroNavigation).WithMany(p => p.DetRegistroRevista)
                .HasForeignKey(d => d.IdRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetRegist__Id_Re__5535A963");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.DetRegistroRevista)
                .HasForeignKey(d => d.IdRevista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetRegist__Id_Re__5629CD9C");
        });

        modelBuilder.Entity<IssnsRevista>(entity =>
        {
            entity.HasKey(e => e.IdIssn).HasName("PK__ISSNsRev__97D35C5C13F66D50");

            entity.ToTable("ISSNsRevista");

            entity.Property(e => e.IdIssn).HasColumnName("Id_ISSN");
            entity.Property(e => e.IdRevista).HasColumnName("Id_Revista");
            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISSN");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.IssnsRevista)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__ISSNsRevi__Id_Re__49C3F6B7");
        });

        modelBuilder.Entity<MetadatosRevistaIssn>(entity =>
        {
            entity.HasKey(e => e.IdRevista).HasName("PK__Metadato__1E641B8AC4232B50");

            entity.ToTable("MetadatosRevistaISSN");

            entity.Property(e => e.IdRevista)
                .ValueGeneratedNever()
                .HasColumnName("Id_Revista");
            entity.Property(e => e.Abdc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABDC");
            entity.Property(e => e.AbdcExiste).HasColumnName("ABDC_Existe");
            entity.Property(e => e.AbdcS).HasColumnName("ABDC_S");
            entity.Property(e => e.Ajg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.Ajg4star)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG_4star");
            entity.Property(e => e.AjgExiste).HasColumnName("AJG_Existe");
            entity.Property(e => e.AjgS).HasColumnName("AJG_S");
            entity.Property(e => e.AlMenosUnaLista)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BeallsList)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Cnrs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.CnrsExiste).HasColumnName("CNRS_Existe");
            entity.Property(e => e.CnrsS).HasColumnName("CNRS_S");
            entity.Property(e => e.CoautoriaEsan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Coautoria_ESAN");
            entity.Property(e => e.Country)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EsciQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESCI_Q");
            entity.Property(e => e.EsciScieloSinScopus).HasColumnName("ESCI_Scielo_Sin_Scopus");
            entity.Property(e => e.Especial216b).HasColumnName("Especial_216B");
            entity.Property(e => e.Insights)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("INSIGHTS");
            entity.Property(e => e.Jif).HasColumnName("JIF");
            entity.Property(e => e.LatamSinEsciExiste).HasColumnName("Latam_Sin_ESCI_Existe");
            entity.Property(e => e.Mdpi)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MDPI");
            entity.Property(e => e.MultidisciplinaryScopus).HasColumnName("Multidisciplinary_SCOPUS");
            entity.Property(e => e.MultidisciplinaryWos).HasColumnName("Multidisciplinary_WOS");
            entity.Property(e => e.MultidisciplinaryWosOScopys).HasColumnName("Multidisciplinary_WOS_O_SCOPYS");
            entity.Property(e => e.MultyAlMenosUnaLista).HasColumnName("Multy_AlMenosUnaLista");
            entity.Property(e => e.PosicionAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Posicion_Autor");
            entity.Property(e => e.Scielo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Scopus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCOPUS");
            entity.Property(e => e.ScopusExiste).HasColumnName("Scopus_Existe");
            entity.Property(e => e.SoloScieloExiste).HasColumnName("Solo_Scielo_Existe");
            entity.Property(e => e.SoloUnaLista)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Top50)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TOP50");
            entity.Property(e => e.WoSEsci)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS_ESCI");
            entity.Property(e => e.WoSEsciExiste).HasColumnName("WoS_ESCI_Existe");
            entity.Property(e => e.WoSLatam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS_LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS_Q");
            entity.Property(e => e.WoSS).HasColumnName("WoS_S");
            entity.Property(e => e.WoSTopExiste).HasColumnName("WoS_Top_Existe");

            entity.HasOne(d => d.IdRevistaNavigation).WithOne(p => p.MetadatosRevistaIssn)
                .HasForeignKey<MetadatosRevistaIssn>(d => d.IdRevista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Metadatos__Id_Re__4CA06362");
        });

        modelBuilder.Entity<PreguntasFrecuentesChatBot>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__1298DD2D7EF3956B");

            entity.Property(e => e.IdPregunta).HasColumnName("Id_Pregunta");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PreguntasFrecuentesChatBot)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Preguntas__idUsu__4222D4EF");
        });

        modelBuilder.Entity<ProfesoresAdmis>(entity =>
        {
            entity.HasKey(e => e.Id_Profesor_Admis).HasName("PK__Profesor__FE7EEAD47F02E431");

            entity.ToTable("Profesores_Admis");

            entity.Property(e => e.Id_Profesor_Admis).HasColumnName("Id_Profesor_Admis");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DNI).HasColumnName("DNI");
            entity.Property(e => e.NombreyApellido)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ProfesoresAdmis)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Profesore__IdCat__3B75D760");
        });

        modelBuilder.Entity<RegistroRevistas>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__3E5D8D4EBFB21B28");

            entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistroRevistas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroR__Id_Us__52593CB8");
        });

        modelBuilder.Entity<Revista>(entity =>
        {
            entity.HasKey(e => e.IdRevista).HasName("PK__Revista__1E641B8A0F104AD8");

            entity.Property(e => e.IdRevista).HasColumnName("Id_Revista");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TipoLista)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RevistaListaCerrada>(entity =>
        {
            entity.HasKey(e => e.IdRevista).HasName("PK__RevistaL__1E641B8A2BAC2329");

            entity.Property(e => e.IdRevista)
                .ValueGeneratedNever()
                .HasColumnName("Id_Revista");
            entity.Property(e => e.Abdc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABDC");
            entity.Property(e => e.Ajg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.Categoria)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Cnrs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.EsciQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESCI_Q");
            entity.Property(e => e.IncentivoUsd).HasColumnName("IncentivoUSD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Scopus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCOPUS");
            entity.Property(e => e.WoSLatam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS_LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS_Q");

            entity.HasOne(d => d.IdRevistaNavigation).WithOne(p => p.RevistaListaCerrada)
                .HasForeignKey<RevistaListaCerrada>(d => d.IdRevista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RevistaLi__Id_Re__4F7CD00D");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E8672D4A2FE");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6DDD8A4D9");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id_Profesor_Admis).HasColumnName("Id_Profesor_Admis");
            entity.Property(e => e.Id_Rol).HasColumnName("Id_Rol");

            entity.HasOne(d => d.IdProfesorAdmisNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.Id_Profesor_Admis)
                .HasConstraintName("FK__Usuario__Id_Prof__3E52440B");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.Id_Rol)
                .HasConstraintName("FK__Usuario__Id_Rol__3F466844");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.Id_Rol)
                .HasConstraintName("FK__Usuario__Id_Rol__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
