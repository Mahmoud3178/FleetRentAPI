using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class Penalty : BaseEntity
    {
        public int RentalContractId { get; set; }
        public RentalContract RentalContract { get; set; }

        public PenaltyType Type { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
    }
}
