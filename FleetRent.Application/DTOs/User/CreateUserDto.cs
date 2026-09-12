using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.DTOs.User;

public class CreateUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; } // "Admin" / "Employee" / "Customer"
    public string? DrivingLicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
}
