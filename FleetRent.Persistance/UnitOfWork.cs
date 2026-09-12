using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using FleetRent.Persistance.Repositories;

namespace FleetRent.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly FleetRentDbContext _context;

    public UnitOfWork(FleetRentDbContext context)
    {
        _context = context;
        Users = new GenericRepository<User>(_context);
        Branches = new GenericRepository<Branch>(_context);
        CarCategories = new GenericRepository<CarCategory>(_context);
        Cars = new GenericRepository<Car>(_context);
        Bookings = new GenericRepository<Booking>(_context);
        RentalContracts = new GenericRepository<RentalContract>(_context);
        CarInspections = new GenericRepository<CarInspection>(_context);
        Penalties = new GenericRepository<Penalty>(_context);
        Payments = new GenericRepository<Payment>(_context);
        MaintenanceRecords = new GenericRepository<MaintenanceRecord>(_context);
    }

    public IGenericRepository<User> Users { get; }
    public IGenericRepository<Branch> Branches { get; }
    public IGenericRepository<CarCategory> CarCategories { get; }
    public IGenericRepository<Car> Cars { get; }
    public IGenericRepository<Booking> Bookings { get; }
    public IGenericRepository<RentalContract> RentalContracts { get; }
    public IGenericRepository<CarInspection> CarInspections { get; }
    public IGenericRepository<Penalty> Penalties { get; }
    public IGenericRepository<Payment> Payments { get; }
    public IGenericRepository<MaintenanceRecord> MaintenanceRecords { get; }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
    {
        _context.Dispose();
    }
}