using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Contract;

public class CheckOutDto
{
    public int BookingId { get; set; }
    public int EmployeeId { get; set; }
    public int PickupMileage { get; set; }
}
