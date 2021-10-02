using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Business.Entities;

namespace Data.Database
{
    public class AcademyContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Plan)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Curso>()
                .HasOne(m => m.Materia)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Curso>()
                .HasOne(m => m.Comision)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comision>()
                .HasOne(m => m.Plan)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Plan>()
                .HasOne(m => m.Especialidad)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Persona>()
                .HasOne(m => m.Plan)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DocenteCurso>()
                .HasOne(m => m.Curso)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DocenteCurso>()
                .HasOne(m => m.Persona)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasOne(m => m.Persona)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(m => m.Persona)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(m => m.Curso)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<AlumnoInscripcion>? AlumnoInscripciones { get; set; }
        public DbSet<Comision>? Comisiones { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<DocenteCurso>? DocentesCursos { get; set; }
        public DbSet<Especialidad>? Especialidades { get; set; }
        public DbSet<Materia>? Materias { get; set; }
        public DbSet<Persona>? Personas { get; set; }
        public DbSet<Plan>? Planes { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public AcademyContext() {}
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) {}
    }
}
