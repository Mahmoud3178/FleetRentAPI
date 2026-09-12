using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FleetRent.Application.DTOs.Car;
using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using FleetRent.Domain.Enums;

namespace FleetRent.Application.Services.CarService;

public class CarService : ICarService   
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
    {
        var cars = await _unitOfWork.Cars.GetAllAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<CarDto?> GetCarByIdAsync(int id)
    {
        var car = await _unitOfWork.Cars.GetByIdAsync(id);
        return car == null ? null : _mapper.Map<CarDto>(car);
    }

    public async Task<CarDto> CreateCarAsync(CreateCarDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        car.Status = CarStatus.Available;
        car.CurrentMileage = 0;

        await _unitOfWork.Cars.AddAsync(car);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CarDto>(car);
    }
}