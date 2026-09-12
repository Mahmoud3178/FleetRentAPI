using AutoMapper;
using FleetRent.Application.DTOs.CarCategory;
using FleetRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Mapping
{
    public class CarCategoryProfile :Profile
    {
        public CarCategoryProfile()
        {
            CreateMap<CarCategory,CarCategoryDto>();
            CreateMap<CreateCarCategoryDto, CarCategory>();
        }
    }
}
