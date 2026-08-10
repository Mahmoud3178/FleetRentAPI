using FleetRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Persistance
{
    public class FleetRentDbContext : DbContext
    {
        public FleetRentDbContext(DbContextOptions<FleetRentDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }
        public DbSet<CarInspection> CarInspections { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
