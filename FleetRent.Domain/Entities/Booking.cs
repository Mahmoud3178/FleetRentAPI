using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatus Status { get; set; }

        public decimal EstimatedCost { get; set; }
    }
}
