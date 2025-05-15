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

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<ChatInstitucional> ChatInstitucional { get; set; }

    public virtual DbSet<DetChatUsuario> DetChatUsuario { get; set; }

    public virtual DbSet<DetRegistroIssn> DetRegistroIssn { get; set; }

    public virtual DbSet<Editorial> Editorial { get; set; }

    public virtual DbSet<Evaluaciones> Evaluaciones { get; set; }

    public virtual DbSet<Feedback> Feedback { get; set; }

    public virtual DbSet<PreguntasFrecuentes> PreguntasFrecuentes { get; set; }

    public virtual DbSet<PresenciaEnListas> PresenciaEnListas { get; set; }

    public virtual DbSet<Profesores> Profesores { get; set; }

    public virtual DbSet<RegistroIssn> RegistroIssn { get; set; }

    public virtual DbSet<Revista> Revista { get; set; }

    public virtual DbSet<RevistaIndexacion> RevistaIndexacion { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Andres;Database=DB_VDI;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autoria>(entity =>
        {
            entity.HasKey(e => e.IdAutoria).HasName("PK__Autoria__C35BB0A7F9F79272");

            entity.Property(e => e.IdAutoria).HasColumnName("Id_autoria");
            entity.Property(e => e.CoautoriaEsan).HasColumnName("Coautoria ESAN");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.PosiciónDelAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Posición del autor");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.Autoria)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__Autoria__Id_revi__5CD6CB2B");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A100C6A2569");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChatInstitucional>(entity =>
        {
            entity.HasKey(e => e.IdChat).HasName("PK__ChatInst__A99B11796A8028E7");

            entity.Property(e => e.IdChat).HasColumnName("Id_Chat");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ChatInstitucional)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ChatInsti__Id_Us__44FF419A");
        });

        modelBuilder.Entity<DetChatUsuario>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdChat).HasColumnName("Id_Chat");
            entity.Property(e => e.PreguntaUsuario).HasColumnType("text");
            entity.Property(e => e.RespuestaSistema).HasColumnType("text");

            entity.HasOne(d => d.IdChatNavigation).WithMany()
                .HasForeignKey(d => d.IdChat)
                .HasConstraintName("FK__DetChatUs__Id_Ch__46E78A0C");
        });

        modelBuilder.Entity<DetRegistroIssn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DetRegistroISSN");

            entity.Property(e => e.IdRegistroIssn).HasColumnName("Id_RegistroISSN");
            entity.Property(e => e.IdRevista).HasColumnName("Id_Revista");
            entity.Property(e => e.IdTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Id_Tipo");

            entity.HasOne(d => d.IdRegistroIssnNavigation).WithMany()
                .HasForeignKey(d => d.IdRegistroIssn)
                .HasConstraintName("FK__DetRegist__Id_Re__5070F446");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany()
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__DetRegist__Id_Re__5165187F");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__Editoria__2249772A0029D392");

            entity.Property(e => e.IdEditorial).HasColumnName("Id_editorial");
            entity.Property(e => e.BeallSList).HasColumnName("BEALL'S LIST");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.Insights).HasColumnName("INSIGHTS");
            entity.Property(e => e.Mdpi).HasColumnName("MDPI");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.Editorial)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__Editorial__Id_re__59FA5E80");
        });

        modelBuilder.Entity<Evaluaciones>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PK__Evaluaci__D30A2CE3443CA5F2");

            entity.Property(e => e.IdEvaluacion).HasColumnName("Id_evaluacion");
            entity.Property(e => e.Abdc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABDC");
            entity.Property(e => e.AbdcExiste).HasColumnName("ABDC Existe");
            entity.Property(e => e.AbdcS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ABDC (S)");
            entity.Property(e => e.Ajg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.Ajg4).HasColumnName("AJG=4*");
            entity.Property(e => e.AjgExiste).HasColumnName("AJG Existe");
            entity.Property(e => e.AjgS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AJG (S)");
            entity.Property(e => e.Cnrs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.CnrsExiste).HasColumnName("CNRS Existe");
            entity.Property(e => e.CnrsS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNRS (S)");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__Evaluacio__Id_re__5441852A");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.IdFeedback).HasName("PK__Feedback__3DA0483F0F10C3E3");

            entity.Property(e => e.IdFeedback).HasColumnName("Id_Feedback");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.IdChat).HasColumnName("Id_Chat");

            entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.Feedback)
                .HasForeignKey(d => d.IdChat)
                .HasConstraintName("FK__Feedback__Id_Cha__49C3F6B7");
        });

        modelBuilder.Entity<PreguntasFrecuentes>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__1298DD2D5966A605");

            entity.Property(e => e.IdPregunta).HasColumnName("Id_Pregunta");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pregunta).HasColumnType("text");
            entity.Property(e => e.Respuesta).HasColumnType("text");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.PreguntasFrecuentes)
                .HasForeignKey(d => d.Usuario)
                .HasConstraintName("FK__Preguntas__Usuar__4222D4EF");
        });

        modelBuilder.Entity<PresenciaEnListas>(entity =>
        {
            entity.HasKey(e => e.IdLista).HasName("PK__Presenci__CFBAEE53F8687F9D");

            entity.Property(e => e.IdLista).HasColumnName("Id_lista");
            entity.Property(e => e.AlMenosEnUnaLista).HasColumnName("Al menos en una lista");
            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.MultyYAlMenosUnaLista).HasColumnName("Multy y al menos una lista");
            entity.Property(e => e.SoloEnUnaLista).HasColumnName("Solo en una lista");
            entity.Property(e => e.Top50).HasColumnName("TOP50");
            entity.Property(e => e._216bEspecial).HasColumnName("2.1.6B especial");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.PresenciaEnListas)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__Presencia__Id_re__571DF1D5");
        });

        modelBuilder.Entity<Profesores>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__C377C3A1847FC778");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.NombreApellido)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Profesore__IdCat__3E52440B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Profesore__IdUsu__3F466844");
        });

        modelBuilder.Entity<RegistroIssn>(entity =>
        {
            entity.HasKey(e => e.IdRegistroIssn).HasName("PK__Registro__B0A8C7172A7FDEC7");

            entity.ToTable("RegistroISSN");

            entity.Property(e => e.IdRegistroIssn).HasColumnName("Id_RegistroISSN");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistroIssn)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__RegistroI__Id_Us__4CA06362");
        });

        modelBuilder.Entity<Revista>(entity =>
        {
            entity.HasKey(e => e.IdRevista).HasName("PK__Revista__3F68F3B29C81BC67");

            entity.Property(e => e.IdRevista).HasColumnName("Id_revista");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISSN");
            entity.Property(e => e.Jif).HasColumnName("JIF");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RevistaIndexacion>(entity =>
        {
            entity.HasKey(e => e.IdIndexacion).HasName("PK__RevistaI__A6512212415B0E19");

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
            entity.Property(e => e.Scopus).HasColumnName("SCOPUS");
            entity.Property(e => e.ScopusExiste).HasColumnName("Scopus Existe");
            entity.Property(e => e.SoloScieloExiste).HasColumnName("Solo Scielo Existe");
            entity.Property(e => e.WoSEsci).HasColumnName("WoS ESCi");
            entity.Property(e => e.WoSEsciExiste).HasColumnName("WoS ESCI Existe");
            entity.Property(e => e.WoSLatam).HasColumnName("WoS LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WoS (Q)");
            entity.Property(e => e.WoSS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WoS (S)");
            entity.Property(e => e.WoSTopExiste).HasColumnName("WoS top Existe");

            entity.HasOne(d => d.IdRevistaNavigation).WithMany(p => p.RevistaIndexacion)
                .HasForeignKey(d => d.IdRevista)
                .HasConstraintName("FK__RevistaIn__Id_re__5FB337D6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E86C616378B");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__771113351EBE2CDE");

            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
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
