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
                    Nombre = "Ale"
                },
                new()
                {
                    Nombre = "Juan"
                }
            };

            context.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
