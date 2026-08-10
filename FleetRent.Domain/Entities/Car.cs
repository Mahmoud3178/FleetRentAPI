using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public CarStatus Status { get; set; }
        public int CurrentMileage { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    }
}
