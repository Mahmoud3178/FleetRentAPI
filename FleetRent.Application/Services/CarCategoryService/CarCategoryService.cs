using AutoMapper;
using FleetRent.Application.DTOs.CarCategory;
using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.CarCategoryService
{
    public class CarCategoryService : ICarCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarCategoryDto>> GetAllCarCategoriesAsync()
        {
            var categories = await _unitOfWork.CarCategories.GetAllAsync();
            return _mapper.Map<IEnumerable<CarCategoryDto>>(categories);
        }

        public async Task<CarCategoryDto?> GetCarCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CarCategories.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CarCategoryDto>(category);
        }

        public async Task<CarCategoryDto> CreateCarCategoryAsync(CreateCarCategoryDto dto)
        {
            var category = _mapper.Map<CarCategory>(dto);

            await _unitOfWork.CarCategories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CarCategoryDto>(category);
        }
    }
}
