using CaravanMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.DataAccess
{
    public class CaravanMvcContext : DbContext
    {
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public CaravanMvcContext(DbContextOptions<CaravanMvcContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wagon>().HasData(
                new Wagon { Id = 1, Name = "Wagon One", NumWheels = 4, Covered = true},
                new Wagon { Id = 2, Name = "Wagon Two", NumWheels = 8, Covered = false }
            );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { Id = 1, Name = "Joey", Age = 23, Destination = "The Gold Coast", WagonId = 1 },
                new Passenger { Id = 2, Name = "Cole", Age = 27, Destination = "The Gold Coast", WagonId = 1 },
                new Passenger { Id = 3, Name = "Jimy", Age = 33, Destination = "The Gold Coast", WagonId = 1 },
                new Passenger { Id = 4, Name = "Joseph", Age = 53, Destination = "The Cold Mid-West", WagonId = 2 },
                new Passenger { Id = 5, Name = "Seth", Age = 24, Destination = "The Cold Mid-West", WagonId = 2 },
                new Passenger { Id = 6, Name = "Gole", Age = 83, Destination = "The Cold Mid-West", WagonId = 2 }
            );
        }
    }
}
