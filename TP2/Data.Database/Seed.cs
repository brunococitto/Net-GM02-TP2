using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Business.Entities;

namespace Data.Database
{
    public class Seed
    {
        public static void SeedData(AcademyContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var especialidades = new List<Especialidad>()
            {
                new()
                {
                    Descripcion = "Ingeniería en Sistemas de Información"
                },
                new()
                {
                    Descripcion = "Ingeniería Química"
                },
                new()
                {
                    Descripcion = "Ingeniería Eléctrica"
                },
                new()
                {
                    Descripcion = "Ingeniería Mecánica"
                },
                new()
                {
                    Descripcion = "Ingeniería Civil"
                }
            };
            var planes = new List<Plan>()
            {
                new()
                {
                    Descripcion = "2008",
                    IDEspecialidad = 1
                },
                new()
                {
                    Descripcion = "1995",
                    IDEspecialidad = 1
                },
                new()
                {
                    Descripcion = "1994",
                    IDEspecialidad = 4
                },
                new()
                {
                    Descripcion = "2009",
                    IDEspecialidad = 3
                }
            };
            var comisiones = new List<Comision>
            {
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Descripcion = "101"
                },
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Descripcion = "102"
                },
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Descripcion = "103"
                },
                new()
                {
                    AnoEspecialidad = 2,
                    IDPlan = 1,
                    Descripcion = "201"
                },
                new()
                {
                    AnoEspecialidad = 4,
                    IDPlan = 3,
                    Descripcion = "402"
                },
                new()
                {
                    AnoEspecialidad = 5,
                    IDPlan = 1,
                    Descripcion = "502"
                }
            };
            var modulos = new List<Modulo>
            {
                new()
                {
                    Descripcion = "ABMC Usuarios"
                },
                new()
                {
                    Descripcion = "ABMC Personas"
                },
                new()
                {
                    Descripcion = "ABMC Cursos"
                }
            };
            var materias = new List<Materia>
            {
                new()
                {
                    Descripcion = "Sistemas de Gestión",
                    HSSemanales = 4,
                    HSTotales = 136,
                    IDPlan = 1
                },
                new()
                {
                    Descripcion = "Administración Gerencial",
                    HSSemanales = 6,
                    HSTotales = 102,
                    IDPlan = 1
                }
            };
            var usuarios = new List<Usuario>()
            {
                new()
                {
                    NombreUsuario = "bcocitto",
                    Clave = "C7C3ECFF956CE64056F4BBC9453C8CA853AFA68E",
                    Apellido = "Cocitto",
                    Nombre = "Bruno",
                    Email = "bcocitto@gmail.com",
                    Habilitado = true
                },
                new()
                {
                    NombreUsuario = "smasetto",
                    Clave = "83762B2C48D3BBA8A4DA6EF5493CA9DAA527FCFA",
                    Apellido = "Masetto",
                    Nombre = "Santiago Nicolás",
                    Email = "masetto98@gmail.com",
                    Habilitado = true
                }
            };
            var cursos = new List<Curso>
            {
                new()
                {
                    AnoCalendario = 2021,
                    Descripcion = "AG_2021_502",
                    IDComision = 6,
                    IDMateria = 2,
                    Cupo = 10
                }
            };

            context.AddRange(especialidades);
            context.AddRange(planes);
            context.AddRange(comisiones);
            context.AddRange(modulos);
            context.AddRange(materias);
            context.AddRange(cursos);
            context.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
