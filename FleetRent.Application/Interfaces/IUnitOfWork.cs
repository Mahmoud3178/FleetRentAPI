using FleetRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        //IGenericRepository<T> Repository<T>() where T : class;

        IGenericRepository<User> Users { get; }
        IGenericRepository<Branch> Branches { get; }
        IGenericRepository<CarCategory> CarCategories { get; }
        IGenericRepository<Car> Cars { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<RentalContract> RentalContracts { get; }
        IGenericRepository<CarInspection> CarInspections { get; }
        IGenericRepository<Penalty> Penalties { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<MaintenanceRecord> MaintenanceRecords { get; }

        Task<int> SaveChangesAsync();
    }
}
