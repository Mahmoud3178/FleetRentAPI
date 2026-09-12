using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.MaintenanceRecord;

public class MaintenanceRecordDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string CarPlateNumber { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Cost { get; set; }
}