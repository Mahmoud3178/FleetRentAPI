using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Payment;

public class PaymentDto
{
    public int Id { get; set; }
    public int RentalContractId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public DateTime PaidAt { get; set; }
}