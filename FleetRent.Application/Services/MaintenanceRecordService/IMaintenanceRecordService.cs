using FleetRent.Application.DTOs.MaintenanceRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.MaintenanceRecordService
{
    public interface IMaintenanceRecordService
    {
        Task<IEnumerable<MaintenanceRecordDto>> GetAllAsync();
        Task<MaintenanceRecordDto?> GetByIdAsync(int id);
        Task<MaintenanceRecordDto> CreateAsync(CreateMaintenanceRecordDto dto);
        Task CompleteMaintenanceAsync(int id);
    }
}
