using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
using RentRide.Core.Clock.Abstracts;
using RentRide.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentRide.Data.Contracts;
using RentRide.Data.Repositories.Abstracts;

namespace RentRide.Data
{
    public static class DataInitializator
    {
        public static async Task Initialize(RentRideDbContext context, UserManager<User> userManager, 
                                            RoleManager<Role> roleManager, IClock clock, IRentRideUnitOfWork unitOfWork)
        {
            await context.Database.MigrateAsync();

            var users = new[]
            {
                new InitUser()
                {
                    Password = "qqwweerr",
                    RoleNames = new[] {RoleNames.Admin},
                    UserName = "Admin",
                    Fullname = "Admin Smith"
                },
                new InitUser()
                {
                    Password = "zxc1v1",
                    RoleNames = new[] {RoleNames.Client},
                    UserName = "User",
                    Fullname = "Sam Rogers"
                }
            };
            var salons = new[]
            {
                new Salon()
                {
                    Location = "Prague",
                    Name = "CzechRent"
                },
                new Salon()
                {
                    Location = "Berlin",
                    Name = "DeutchRent"
                },
                new Salon()
                {
                    Location = "Minsk",
                    Name = "BelRent"
                }
            };
            var carModels = new[]
            {
                new CarModel()
                {
                    Year = 1999,
                    Model = "F1",
                    Engine = "Mercedes-Benz FO110H (72°)",
                    Carcase = "Sport car",
                    Color = "Silver",
                    Price = 85780,
                    RentCoefficient = (float)2.4
                },
                new CarModel()
                {
                    Year = 2019,
                    Model = "Model S",
                    Engine = "615 kW (825 bhp), 1,300 N⋅m (960 lb⋅ft), 3-phase AC induction motor",
                    Carcase = "Coupe",
                    Color = "Dark Red",
                    Price = 65220,
                    RentCoefficient = (float)2.2
                },
                new CarModel()
                {
                    Year = 2015,
                    Model = "Vesta",
                    Engine = "Nissan-Renault HR16DE-H4M",
                    Carcase = "Coupe",
                    Color = "Brown",
                    Price = 15220,
                    RentCoefficient = (float)1.2
                },
                new CarModel()
                {
                    Year = 2015,
                    Model = "Vesta",
                    Engine = "ВАЗ-21179",
                    Carcase = "Coupe",
                    Color = "Black",
                    Price = 13740,
                    RentCoefficient = (float)1.1
                },
                new CarModel()
                {
                    Year = 2021,
                    Model = "Tiguan",
                    Engine = "Volkswagen 1.4 TSI",
                    Carcase = "HatchBack",
                    Color = "Olive",
                    Price = 24100,
                    RentCoefficient = (float)1.5
                }
            };
            var cars = new[]
            {
                new Car()
                {
                    Brand = "McLaren",
                    CarModel = carModels[0],
                    Salon = salons[0],
                    SerialNumber = "CT879GW"
                },
                new Car()
                {
                    Brand = "McLaren",
                    CarModel = carModels[0],
                    Salon = salons[1],
                    SerialNumber = "CB455BE"
                },
                new Car()
                {
                    Brand = "Tesla",
                    CarModel = carModels[1],
                    Salon = salons[0],
                    SerialNumber = "LT612CZ"
                },
                new Car()
                {
                    Brand = "Lada",
                    CarModel = carModels[2],
                    Salon = salons[2],
                    SerialNumber = "7724AX-3"
                },
                new Car()
                {
                    Brand = "Lada",
                    CarModel = carModels[3],
                    Salon = salons[2],
                    SerialNumber = "9094AB-7"
                },
                new Car()
                {
                    Brand="Volkswagen",
                    CarModel = carModels[4],
                    Salon = salons[1],
                    SerialNumber = "BZ670GR"
                }
            };

            await AddOrUpdateRolesAsync(users, roleManager);
            await AddOrUpdateUsersAsync(users, userManager, clock);
            await AddCarModelsAsync(unitOfWork.CarModels, carModels);
            await AddSalonsAsync(unitOfWork.Salons, salons);
            await AddCarsAsync(unitOfWork.Cars, cars);
        }

        private static async Task AddOrUpdateUsersAsync(IEnumerable<InitUser> users,
                                UserManager<User> userManager, IClock clock)
        {
            foreach (var user in users)
            {
                var registeredUser = await userManager.FindByNameAsync(user.UserName);
                if (registeredUser == null)
                {
                    var newUser = new User()
                    {
                        Fullname = user.Fullname,
                        UserName = user.UserName,
                        Roles = new List<Role>(),
                        CreationTime = clock.UtcNow
                    };
                    await userManager.CreateAsync(newUser, user.Password);

                    await userManager.AddToRolesAsync(newUser, user.RoleNames);
                }
                else
                {
                    var removedRoles = registeredUser.Roles
                        .Select(role => role.Name).Except(user.RoleNames);

                    await userManager.RemoveFromRolesAsync(registeredUser, removedRoles);

                    var addedRoles = user.RoleNames.Except(registeredUser.Roles.Select(role => role.Name));

                    await userManager.AddToRolesAsync(registeredUser, addedRoles);

                    await userManager.UpdateAsync(registeredUser);
                }
            }
        }

        private static async Task AddOrUpdateRolesAsync(IEnumerable<InitUser> users, RoleManager<Role> roleManager)
        {
            var rolesNames = users
                .SelectMany(user => user.RoleNames)
                .Distinct()
                .Select(role => role.ToUpper());

            foreach (var roleName in rolesNames)
            {
                var existedRole = await roleManager.FindByNameAsync(roleName);
                if (existedRole == null)
                {
                    await roleManager.CreateAsync(new Role() { Name = roleName });
                }
                else
                {
                    await roleManager.UpdateAsync(existedRole);
                }
            }
        }

        private static async Task AddCarModelsAsync(ICarModelRepository carModelsRepository, CarModel[] carModels)
        {
            var existedCarModels = await carModelsRepository.GetAllAsync();
            if (existedCarModels.Count == 0)
            {
                foreach (var model in carModels)
                {
                    await carModelsRepository.CreateAsync(model);
                }        
            }
            
        }
        private static async Task AddCarsAsync(ICarRepository carRepository, Car[] cars)
        {
            var existedCars = await carRepository.GetAllAsync();
            if (existedCars.Count == 0)
            {
                foreach (var car in cars)
                {
                    await carRepository.CreateAsync(car);
                }        
            }
            
        }

        private static async Task AddSalonsAsync(ISalonRepository salonRepository, Salon[] salons)
        {
            var existedSalons = await  salonRepository.GetAllAsync();
            if (existedSalons.Count == 0)
            {
                foreach (var salon in salons)
                {
                    await salonRepository.CreateAsync(salon);
                }
            }
        }

        private class InitUser
        {
            public string Fullname { get; set; }
            public string UserName { get; init; }
            
            public string Password { get; init; }

            public string[] RoleNames { get; init; }
        }
    }
}