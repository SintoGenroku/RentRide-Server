using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RentRide.Core.Clock.Abstracts;
using RentRide.Data;
using RentRide.DomainModels;
using System;
using System.Threading.Tasks;

namespace RentRide.WebApplication.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static async Task CreateDbIfNotExist(this IServiceProvider serviceProvider)
        {
            using(var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<RentRideDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services. GetRequiredService<RoleManager<Role>>();
                var clock = services.GetRequiredService<IClock>();
                var unitOfWork = services.GetRequiredService<IRentRideUnitOfWork>();
                await DataInitializator.Initialize(context, userManager, roleManager, clock, unitOfWork);
            }
        }
    }
}