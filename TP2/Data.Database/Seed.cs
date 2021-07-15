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
                }
            };

            context.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
