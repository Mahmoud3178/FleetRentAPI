using AutoMapper;
using FleetRent.Application.DTOs.Booking;
using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllAsync()
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> CreateBookingAsync(CreateBookingDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                throw new Exception("تاريخ النهاية لازم يكون بعد تاريخ البداية");

            if (dto.StartDate < DateTime.Now)
                throw new Exception("مينفعش تحجز في تاريخ فات");

            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarId);
            if (car == null)
                throw new Exception("العربية غير موجودة");

            if (car.Status != CarStatus.Available)
                throw new Exception("العربية غير متاحة حاليًا");

            var customer = await _unitOfWork.Users.GetByIdAsync(dto.CustomerId);
            if (customer == null)
                throw new Exception("العميل غير موجود");

            if (customer.LicenseExpiryDate == null || customer.LicenseExpiryDate < dto.StartDate)
                throw new Exception("رخصة القيادة منتهية أو غير مسجلة");

            // قاعدة التعارض: مفيش حجز تاني على نفس العربية في نفس الفترة
            bool overlapping = await _unitOfWork.Bookings.AnyAsync(b =>
                b.CarId == dto.CarId &&
                b.Status != BookingStatus.Cancelled &&
                dto.StartDate < b.EndDate &&
                dto.EndDate > b.StartDate);

            if (overlapping)
                throw new Exception("العربية محجوزة بالفعل في الفترة دي");

            var days = (dto.EndDate - dto.StartDate).Days;
            if (days == 0) days = 1;

            var booking = _mapper.Map<Booking>(dto);
            booking.Status = BookingStatus.Pending;
            booking.EstimatedCost = days * car.CarCategory.DailyRate;

            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task CancelBookingAsync(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null)
                throw new Exception("الحجز غير موجود");

            booking.Status = BookingStatus.Cancelled;
            _unitOfWork.Bookings.Update(booking);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
