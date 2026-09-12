using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Contract;

public class ContractDto
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime ActualPickupDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
}
