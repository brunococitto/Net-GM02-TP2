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
                },
                new()
                {
                    Descripcion = "Administrativo"
                }
            };
            var planes = new List<Plan>()
            {
                new()
                {
                    Descripcion = "2008",
                    IDEspecialidad = 1,
                    Especialidad = especialidades[0]
                },
                new()
                {
                    Descripcion = "1995",
                    IDEspecialidad = 1,
                    Especialidad = especialidades[0]
                },
                new()
                {
                    Descripcion = "1994",
                    IDEspecialidad = 4,
                    Especialidad = especialidades[3]
                },
                new()
                {
                    Descripcion = "2009",
                    IDEspecialidad = 3,
                    Especialidad = especialidades[2]
                },
                new()
                {
                    Descripcion = "2003",
                    IDEspecialidad = 1,
                    Especialidad = especialidades[0]
                }
            };
            var comisiones = new List<Comision>
            {
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Plan = planes[0],
                    Descripcion = "101"
                },
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Plan = planes[0],
                    Descripcion = "102"
                },
                new()
                {
                    AnoEspecialidad = 1,
                    IDPlan = 1,
                    Plan = planes[0],
                    Descripcion = "103"
                },
                new()
                {
                    AnoEspecialidad = 2,
                    IDPlan = 1,
                    Plan = planes[0],
                    Descripcion = "201"
                },
                new()
                {
                    AnoEspecialidad = 4,
                    IDPlan = 3,
                    Plan = planes[2],
                    Descripcion = "402"
                },
                new()
                {
                    AnoEspecialidad = 5,
                    IDPlan = 1,
                    Plan = planes[0],
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
                    IDPlan = 1,
                    Plan = planes[0]
                },
                new()
                {
                    Descripcion = "Administración Gerencial",
                    HSSemanales = 6,
                    HSTotales = 102,
                    IDPlan = 1,
                    Plan = planes[0]
                }
            };
            var cursos = new List<Curso>
            {
                new()
                {
                    AnoCalendario = 2021,
                    Descripcion = "AG_2021_502",
                    IDComision = 1,
                    Comision = comisiones[0],
                    IDMateria = 1,
                    Materia = materias[0],
                    Cupo = 10
                },
                new()
                {
                    AnoCalendario = 2021,
                    Descripcion = "SdG_2021_502",
                    IDComision = 1,
                    Comision = comisiones[0],
                    IDMateria = 2,
                    Materia = materias[1],
                    Cupo = 10
                }
            };
            var personas = new List<Persona>
            {
                new()
                {
                    Nombre = "Bruno",
                    Apellido = "Cocitto",
                    Direccion = "Calle falsa 123",
                    Telefono = "0303456",
                    Email = "bcocitto@gmail.com",
                    FechaNacimiento = new DateTime(2011, 12, 01),
                    Legajo = 45214,
                    IDPlan = null,
                    Plan = null,
                    TipoPersona = Persona.TiposPersona.Administrativo
                },
                new()
                {
                    Nombre = "Santiago",
                    Apellido = "Masetto",
                    Direccion = "Calle falsa 123",
                    Telefono = "0303456",
                    Email = "smasetto@gmail.com",
                    FechaNacimiento = new DateTime(2011, 12, 01),
                    Legajo = 44996,
                    IDPlan = 4,
                    Plan = planes[3],
                    TipoPersona = Persona.TiposPersona.Profesor
                },
                new()
                {
                    Nombre = "Franco",
                    Apellido = "Schiavoni",
                    Direccion = "Calle falsa 123",
                    Telefono = "0303456",
                    Email = "fschiavoni@gmail.com",
                    FechaNacimiento = new DateTime(2011, 12, 01),
                    Legajo = 44123,
                    IDPlan = 4,
                    Plan = planes[3],
                    TipoPersona = Persona.TiposPersona.Profesor
                },
                new()
                {
                    Nombre = "Manuel",
                    Apellido = "Dorado",
                    Direccion = "Calle falsa 123",
                    Telefono = "0303456",
                    Email = "mdorado@gmail.com",
                    FechaNacimiento = new DateTime(2011, 12, 01),
                    Legajo = 44997,
                    IDPlan = 4,
                    Plan = planes[3],
                    TipoPersona = Persona.TiposPersona.Alumno
                }
            };
            var usuarios = new List<Usuario>()
            {
                new()
                {
                    NombreUsuario = "bcocitto",
                    Clave = "C7C3ECFF956CE64056F4BBC9453C8CA853AFA68E",
                    IDPersona = 3,
                    Persona = personas[2],
                    Habilitado = true
                },
                new()
                {
                    NombreUsuario = "smasetto",
                    Clave = "83762B2C48D3BBA8A4DA6EF5493CA9DAA527FCFA",
                    IDPersona = 2,
                    Persona = personas[1],
                    Habilitado = true
                },
                new()
                {
                    NombreUsuario = "fschiavoni",
                    Clave = "AAEF5F07A9DCB37E082D23871E558B3FBDC13EE2",
                    IDPersona = 3,
                    Persona = personas[2],
                    Habilitado = true
                },
                new()
                {
                    NombreUsuario = "mdorado",
                    Clave = "83E83B756D616723B0C53754387AA0647BDF7CDC",
                    IDPersona = 4,
                    Persona = personas[3],
                    Habilitado = true
                }
            };
            var inscripciones = new List<AlumnoInscripcion>
            {
                new()
                {
                    Condicion = "Regular",
                    IDAlumno = 1,
                    IDCurso = 1,
                    Nota = 0,
                    Persona = personas[0],
                    Curso = cursos[0]
                }
            };
            var asignaciones = new List<DocenteCurso>
            {
                new()
                {
                    IDDocente = 1,
                    IDCurso = 1,
                    Cargo = DocenteCurso.TiposCargo.Auxiliar,
                    Persona = personas[1],
                    Curso = cursos[0]
                }
            };

            context.AddRange(asignaciones);
            context.AddRange(inscripciones);
            context.AddRange(personas);
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
