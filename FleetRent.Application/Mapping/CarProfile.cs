using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FleetRent.Application.DTOs.Car;
using FleetRent.Domain.Entities;

namespace FleetRent.Application.Mapping;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CarCategory.Name));

        CreateMap<CreateCarDto, Car>();
    }
}
