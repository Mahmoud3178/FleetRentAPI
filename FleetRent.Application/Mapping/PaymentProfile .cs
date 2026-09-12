using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FleetRent.Application.DTOs.Payment;
using FleetRent.Domain.Entities;
using FleetRent.Domain.Enums;

namespace FleetRent.Application.Mapping;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

        CreateMap<CreatePaymentDto, Payment>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<PaymentType>(src.Type)))
            .ForMember(dest => dest.PaidAt, opt => opt.MapFrom(src => DateTime.Now));
    }
}