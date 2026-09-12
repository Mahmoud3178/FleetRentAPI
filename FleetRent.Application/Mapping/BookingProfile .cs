using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FleetRent.Application.DTOs.Booking;
using FleetRent.Domain.Entities;

namespace FleetRent.Application.Mapping;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
            .ForMember(dest => dest.CarPlateNumber, opt => opt.MapFrom(src => src.Car.PlateNumber));

        CreateMap<CreateBookingDto, Booking>();
    }
}
