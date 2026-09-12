using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Contract;

public class CheckInDto
{
    public int ContractId { get; set; }
    public int ReturnMileage { get; set; }
    public bool HasDamage { get; set; }
    public string? DamageNotes { get; set; }
    public decimal EstimatedDamageCost { get; set; }
}