using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FleetRent.Application.DTOs.MaintenanceRecord;
using FleetRent.Domain.Entities;

namespace FleetRent.Application.Mapping;

public class MaintenanceRecordProfile : Profile
{
    public MaintenanceRecordProfile()
    {
        CreateMap<MaintenanceRecord, MaintenanceRecordDto>()
            .ForMember(dest => dest.CarPlateNumber, opt => opt.MapFrom(src => src.Car.PlateNumber));

        CreateMap<CreateMaintenanceRecordDto, MaintenanceRecord>();
    }
}