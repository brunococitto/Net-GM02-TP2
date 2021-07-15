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
        public DbSet<AlumnoInscripcion>? AlumnoInscripciones { get; set; }
        public DbSet<Comision>? Comisiones { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<DocenteCurso>? DocentesCursos { get; set; }
        public DbSet<Especialidad>? Especialidades { get; set; }
        public DbSet<Materia>? Materias { get; set; }
        public DbSet<Modulo>? Modulos { get; set; }
        public DbSet<ModuloUsuario>? ModulosUsuarios { get; set; }
        public DbSet<Persona>? Personas { get; set; }
        public DbSet<Plan>? Planes { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public AcademyContext() {}
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) {}
    }
}
