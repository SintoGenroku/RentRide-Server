using Microsoft.EntityFrameworkCore;
using RentRide.DomainModels;

namespace RentRide.Data
{
    public class RentRideDbContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<User> Users { get; set; }

       public RentRideDbContext(DbContextOptions<RentRideDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(e => e.Roles)
                .WithMany(e => e.Users);

                u.HasMany(e => e.Contracts)
                .WithOne(e => e.Client);

                u.Property(e => e.CreationTime).HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Salon>(s =>
            {
                s.HasMany(e => e.Cars)
                .WithOne(e => e.Salon);

                s.HasMany(e => e.Contracts)
                .WithOne(e => e.Salon);
            });

            modelBuilder.Entity<CarModel>(c =>
            {
                c.HasMany(e => e.Cars)
                .WithOne(e => e.CarModel).HasForeignKey(c => c.CarModelId);
            });

            modelBuilder.Entity<Contract>(c =>
            {
                c.HasOne(e => e.Car)
                .WithOne(e => e.RentContract).HasForeignKey<Contract>(e => e.CarId);
            });
        }

    }
}
