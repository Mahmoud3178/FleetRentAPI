using AutoMapper;
using FleetRent.Application.DTOs.Contract;
using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.ContractService
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractDto>> GetAllAsync()
        {
            var contracts = await _unitOfWork.RentalContracts.GetAllAsync();
            return _mapper.Map<IEnumerable<ContractDto>>(contracts);
        }

        public async Task<ContractDto?> GetByIdAsync(int id)
        {
            var contract = await _unitOfWork.RentalContracts.GetByIdAsync(id);
            return contract == null ? null : _mapper.Map<ContractDto>(contract);
        }

        // ============ Check-Out: تسليم العربية للعميل ============
        public async Task<ContractDto> CheckOutCarAsync(CheckOutDto dto)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(dto.BookingId);
            if (booking == null)
                throw new Exception("الحجز غير موجود");

            if (booking.Status != BookingStatus.Pending && booking.Status != BookingStatus.Confirmed)
                throw new Exception("الحجز لازم يكون في حالة تسمح بالتسليم");

            var car = await _unitOfWork.Cars.GetByIdAsync(booking.CarId);
            if (car.Status != CarStatus.Available)
                throw new Exception("العربية غير متاحة للتسليم حاليًا");

            var contract = new RentalContract
            {
                BookingId = booking.Id,
                EmployeeId = dto.EmployeeId,
                ActualPickupDate = DateTime.Now,
                Status = ContractStatus.Active,
                TotalAmount = booking.EstimatedCost
            };

            await _unitOfWork.RentalContracts.AddAsync(contract);
            await _unitOfWork.SaveChangesAsync(); // عشان ناخد الـ contract.Id قبل الفحص

            var inspection = new CarInspection
            {
                RentalContractId = contract.Id,
                Type = InspectionType.AtPickup,
                MileageAtInspection = dto.PickupMileage,
                HasDamage = false
            };
            await _unitOfWork.CarInspections.AddAsync(inspection);

            car.Status = CarStatus.Rented;
            car.CurrentMileage = dto.PickupMileage;
            _unitOfWork.Cars.Update(car);

            booking.Status = BookingStatus.Confirmed;
            _unitOfWork.Bookings.Update(booking);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ContractDto>(contract);
        }

        // ============ Check-In: استلام العربية وحساب الغرامات ============
        public async Task<ContractSummaryDto> CheckInCarAsync(CheckInDto dto)
        {
            var contract = await _unitOfWork.RentalContracts.GetByIdAsync(dto.ContractId);
            if (contract == null)
                throw new Exception("العقد غير موجود");

            if (contract.Status != ContractStatus.Active)
                throw new Exception("العقد ده مقفول بالفعل");

            var booking = await _unitOfWork.Bookings.GetByIdAsync(contract.BookingId);
            var car = await _unitOfWork.Cars.GetByIdAsync(booking.CarId);

            contract.ActualReturnDate = DateTime.Now;

            var penaltiesApplied = new List<string>();
            decimal totalPenalties = 0;

            // فحص الاستلام
            var inspection = new CarInspection
            {
                RentalContractId = contract.Id,
                Type = InspectionType.AtReturn,
                MileageAtInspection = dto.ReturnMileage,
                HasDamage = dto.HasDamage,
                DamageNotes = dto.DamageNotes
            };
            await _unitOfWork.CarInspections.AddAsync(inspection);

            // قاعدة 1: غرامة التأخير
            if (contract.ActualReturnDate > booking.EndDate)
            {
                int lateDays = (contract.ActualReturnDate.Value - booking.EndDate).Days;
                if (lateDays > 0)
                {
                    decimal lateFee = lateDays * (car.CarCategory.DailyRate * 1.5m);

                    await _unitOfWork.Penalties.AddAsync(new Penalty
                    {
                        RentalContractId = contract.Id,
                        Type = PenaltyType.LateReturn,
                        Amount = lateFee,
                        Reason = $"تأخير {lateDays} يوم"
                    });

                    totalPenalties += lateFee;
                    penaltiesApplied.Add($"غرامة تأخير: {lateFee:C} ({lateDays} يوم)");
                }
            }

            // قاعدة 2: غرامة الأضرار
            if (dto.HasDamage)
            {
                await _unitOfWork.Penalties.AddAsync(new Penalty
                {
                    RentalContractId = contract.Id,
                    Type = PenaltyType.Damage,
                    Amount = dto.EstimatedDamageCost,
                    Reason = dto.DamageNotes ?? "أضرار بالعربية"
                });

                totalPenalties += dto.EstimatedDamageCost;
                penaltiesApplied.Add($"غرامة أضرار: {dto.EstimatedDamageCost:C}");
            }

            // تحديث العربية
            car.Status = dto.HasDamage ? CarStatus.UnderMaintenance : CarStatus.Available;
            car.CurrentMileage = dto.ReturnMileage;
            _unitOfWork.Cars.Update(car);

            // تحديث الحجز والعقد
            booking.Status = BookingStatus.Completed;
            _unitOfWork.Bookings.Update(booking);

            contract.Status = ContractStatus.Closed;
            contract.TotalAmount += totalPenalties;
            _unitOfWork.RentalContracts.Update(contract);

            await _unitOfWork.SaveChangesAsync();

            return new ContractSummaryDto
            {
                TotalAmount = contract.TotalAmount,
                PenaltiesApplied = penaltiesApplied
            };
        }
    }
}
