using FleetRent.Application.DTOs.CarCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.CarCategoryService
{
    public interface ICarCategoryService
    {
        Task<IEnumerable<CarCategoryDto>> GetAllCarCategoriesAsync();
        Task<CarCategoryDto?> GetCarCategoryByIdAsync(int id);
        Task<CarCategoryDto> CreateCarCategoryAsync(CreateCarCategoryDto dto);
    }
}
