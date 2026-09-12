using FleetRent.Application.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.BranchService
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDto>>GetAllBranchesAsync();
        Task<BranchDto?>GetBranchByIdAsync(int id);
        Task<BranchDto?> CreateBranchAsync(CreateBranchDto dto);
    }
}
