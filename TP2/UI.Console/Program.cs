using System;
using Data.Database;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Usuarios>();
                services.AddDbContext<AcademyContext>(opt =>
                {
                    opt.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnStringLocal"].ConnectionString);
                });
            }).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<AcademyContext>();
                Seed.SeedData(dbContext);

                var Usuarios = services.ServiceProvider.GetRequiredService<Usuarios>();
                Usuarios.Menu();
            }
        }
    }
}
