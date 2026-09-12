using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.Car;

public class CarDto
{
    public int Id { get; set; }
    public string PlateNumber { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
    public string Status { get; set; }
    public int CurrentMileage { get; set; }
    public string BranchName { get; set; }
    public string CategoryName { get; set; }
}
