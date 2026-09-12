using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Contract;

public class ContractSummaryDto
{
    public decimal TotalAmount { get; set; }
    public List<string> PenaltiesApplied { get; set; } = new();
}