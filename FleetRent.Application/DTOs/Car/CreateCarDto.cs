using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Car;

public class CreateCarDto
{
    public string PlateNumber { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
    public int BranchId { get; set; }
    public int CarCategoryId { get; set; }
}
