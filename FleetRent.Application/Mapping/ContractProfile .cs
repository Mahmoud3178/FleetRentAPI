using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FleetRent.Application.DTOs.Contract;
using FleetRent.Domain.Entities;

namespace FleetRent.Application.Mapping;

public class ContractProfile : Profile
{
    public ContractProfile()
    {
        CreateMap<RentalContract, ContractDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName));
    }
}