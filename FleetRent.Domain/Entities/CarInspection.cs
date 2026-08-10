using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Domain.Entities
{
    public class CarInspection : BaseEntity
    {
        public int RentalContractId { get; set; }
        public RentalContract RentalContract { get; set; }

        public InspectionType Type { get; set; }
        public int MileageAtInspection { get; set; }
        public string? DamageNotes { get; set; }
        public bool HasDamage { get; set; }
    }
}
