using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class RentalContract : BaseEntity
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int EmployeeId { get; set; }
        public User Employee { get; set; }

        public DateTime ActualPickupDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public ContractStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();
        public ICollection<CarInspection> Inspections { get; set; } = new List<CarInspection>();
    }
}
