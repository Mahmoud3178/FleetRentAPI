using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.MaintenanceRecord;

public class CreateMaintenanceRecordDto
{
    public int CarId { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Cost { get; set; }
}