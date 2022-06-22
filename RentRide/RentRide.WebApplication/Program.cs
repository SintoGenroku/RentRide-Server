using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RentRide.Core.Clock.Abstracts;
using RentRide.Data;
using RentRide.DomainModels;
using RentRide.WebApplication.Extensions;

namespace RentRide.WebApplication
{
    public class Program
    {
        public static async  Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await CreateDatabaseIfNotExists(host);

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
        
        private static async Task CreateDatabaseIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //var logger = services.GetRequiredService<ILogger>();
                try
                {
                    var context = services.GetRequiredService<RentRideDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services. GetRequiredService<RoleManager<Role>>();
                    var clock = services.GetRequiredService<IClock>();
                    var unitOfWork = services.GetRequiredService<IRentRideUnitOfWork>();
                    await DataInitializator.Initialize(context, userManager, roleManager, clock, unitOfWork);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}