using FleetRent.Application.DTOs.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.ContractService
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDto>> GetAllAsync();
        Task<ContractDto?> GetByIdAsync(int id);
        Task<ContractDto> CheckOutCarAsync(CheckOutDto dto);
        Task<ContractSummaryDto> CheckInCarAsync(CheckInDto dto);
    }
}
