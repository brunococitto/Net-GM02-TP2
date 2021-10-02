using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Data.Database;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<AcademyContext>();
                Seed.SeedData(dbContext, new Hasher());
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
