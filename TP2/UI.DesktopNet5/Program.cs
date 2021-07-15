using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Business.Logic;
using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<formMain>();
                services.AddDbContext<AcademyContext>(opt =>
                {
                    opt.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnStringLocal"].ConnectionString);
                });
            }).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<AcademyContext>();
                Seed.SeedData(dbContext);

                var formMain = services.ServiceProvider.GetRequiredService<formMain>();
                Application.Run(formMain);
            }
        }
    }
}
