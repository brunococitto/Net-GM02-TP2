﻿// <auto-generated />
using System;
using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Database.Migrations
{
    [DbContext(typeof(AcademyContext))]
    [Migration("20210715204310_update-5")]
    partial class update5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Entities.AlumnoInscripcion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDAlumno")
                        .HasColumnType("int");

                    b.Property<int>("IDCurso")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AlumnoInscripciones");
                });

            modelBuilder.Entity("Business.Entities.Comision", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoEspecialidad")
                        .HasColumnType("int")
                        .HasColumnName("anio_especialidad");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_comision");

                    b.Property<int>("IDPlan")
                        .HasColumnType("int")
                        .HasColumnName("id_plan");

                    b.HasKey("ID");

                    b.ToTable("Comisiones");
                });

            modelBuilder.Entity("Business.Entities.Curso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoCalendario")
                        .HasColumnType("int")
                        .HasColumnName("anio_calendario");

                    b.Property<int>("Cupo")
                        .HasColumnType("int")
                        .HasColumnName("cupo");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_curso");

                    b.Property<int>("IDComision")
                        .HasColumnType("int")
                        .HasColumnName("id_comision");

                    b.Property<int>("IDMateria")
                        .HasColumnType("int")
                        .HasColumnName("id_materia");

                    b.HasKey("ID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Business.Entities.DocenteCurso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<int>("IDCurso")
                        .HasColumnType("int");

                    b.Property<int>("IDDocente")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DocentesCursos");
                });

            modelBuilder.Entity("Business.Entities.Especialidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_especialidad");

                    b.HasKey("ID");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Business.Entities.Materia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_materia");

                    b.Property<int>("HSSemanales")
                        .HasColumnType("int")
                        .HasColumnName("hs_semanales");

                    b.Property<int>("HSTotales")
                        .HasColumnType("int")
                        .HasColumnName("hs_totales");

                    b.Property<int>("IDPlan")
                        .HasColumnType("int")
                        .HasColumnName("id_plan");

                    b.HasKey("ID");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Business.Entities.Modulo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_modulo");

                    b.HasKey("ID");

                    b.ToTable("Modulos");
                });

            modelBuilder.Entity("Business.Entities.ModuloUsuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdModulo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("PermiteAlta")
                        .HasColumnType("bit");

                    b.Property<bool>("PermiteBaja")
                        .HasColumnType("bit");

                    b.Property<bool>("PermiteConsulta")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ModulosUsuarios");
                });

            modelBuilder.Entity("Business.Entities.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDPlan")
                        .HasColumnType("int");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPersona")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Business.Entities.Plan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc_plan");

                    b.Property<int>("IDEspecialidad")
                        .HasColumnType("int")
                        .HasColumnName("id_especialidad");

                    b.HasKey("ID");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Business.Entities.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellido");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clave");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("habilitado");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre_usuario");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
