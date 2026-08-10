using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int RentalContractId { get; set; }
        public RentalContract RentalContract { get; set; }

        public decimal Amount { get; set; }
        public PaymentType Type { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
