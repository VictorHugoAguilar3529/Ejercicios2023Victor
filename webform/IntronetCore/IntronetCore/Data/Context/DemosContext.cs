using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IntronetCore.Data.Models;

namespace IntronetCore.Data.Context
{
    public partial class DemosContext : DbContext
    {
        public DemosContext()
        {
        }

        public DemosContext(DbContextOptions<DemosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<AlumnosBaja> AlumnosBajas { get; set; } = null!;
        public virtual DbSet<CatCurso> CatCursos { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<CursosAlumno> CursosAlumnos { get; set; } = null!;
        public virtual DbSet<CursosInstructore> CursosInstructores { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<EstatusAlumno> EstatusAlumnos { get; set; } = null!;
        public virtual DbSet<Instructore> Instructores { get; set; } = null!;
        public virtual DbSet<Saldo> Saldos { get; set; } = null!;
        public virtual DbSet<TablaIsr> TablaIsrs { get; set; } = null!;
        public virtual DbSet<Transaccione> Transacciones { get; set; } = null!;
        public virtual DbSet<VAlumno> VAlumnos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdEstadoOrigen).HasColumnName("idEstadoOrigen");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Sueldo)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("sueldo");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength();
            });

            modelBuilder.Entity<AlumnosBaja>(entity =>
            {
                entity.ToTable("AlumnosBaja");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatCurso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clave)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdPreRequisito).HasColumnName("idPreRequisito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaInicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Fechatermino)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("fechatermino");

                entity.Property(e => e.IdCatCurso).HasColumnName("idCatCurso");

                entity.HasOne(d => d.IdCatCursoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCatCurso)
                    .HasConstraintName("FK_Cursos_CatCursos");
            });

            modelBuilder.Entity<CursosAlumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("date")
                    .HasColumnName("fechaInscripcion");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            });

            modelBuilder.Entity<CursosInstructore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaContratacion");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosInstructores)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__CursosIns__idCur__21B6055D");

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.CursosInstructores)
                    .HasForeignKey(d => d.IdInstructor)
                    .HasConstraintName("FK__CursosIns__idIns__22AA2996");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstatusAlumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instructore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.CuotaHora)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("cuotaHora");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("rfc")
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Saldo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo1)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("Saldo");
            });

            modelBuilder.Entity<TablaIsr>(entity =>
            {
                entity.ToTable("TablaISR");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuotaFija).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ExedLimInf).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.LimInf).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.LimSup).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Subsidio).HasColumnType("decimal(19, 2)");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDestino).HasColumnName("idDestino");

                entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("monto");
            });

            modelBuilder.Entity<VAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Alumnos");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoMaterno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido_paterno");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
