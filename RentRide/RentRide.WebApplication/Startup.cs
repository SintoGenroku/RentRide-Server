using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentRide.Core.Clock;
using RentRide.Core.Clock.Abstracts;
using RentRide.Data;
using RentRide.Data.Stores;
using RentRide.DomainModels;
using RentRide.Foundation.Services;
using RentRide.Foundation.Services.Abstracts;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace RentRide.WebApplication
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<RentRideDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("RentRide.Data")));

            services.AddScoped<IRentRideUnitOfWork, RentRideUnitOfWork>();

            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddRoleStore<RoleStore>()
                .AddUserStore<UserStore>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddSingleton<IClock, Clock>();
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RentRide.API", 
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "SintoGenroku",
                        Email = "borozda.a.s@gmail.com",
                        Url = new Uri("https://github.com/SintoGenroku")
                    }
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "RentRide.WebApplication.xml");
                options.IncludeXmlComments(filePath);
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddAutoMapper(configuration => { configuration.AddMaps(typeof(Program).Assembly); });
        }

        public async void  Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "RentRide.API v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            
        }
        
    }
}