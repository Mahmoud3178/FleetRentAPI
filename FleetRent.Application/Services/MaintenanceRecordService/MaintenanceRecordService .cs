using AutoMapper;
using FleetRent.Application.DTOs.MaintenanceRecord;
using FleetRent.Application.Interfaces;
using FleetRent.Domain.Entities;
using FleetRent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetRent.Application.Services.MaintenanceRecordService
{
    public class MaintenanceRecordService : IMaintenanceRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaintenanceRecordDto>> GetAllAsync()
        {
            var records = await _unitOfWork.MaintenanceRecords.GetAllAsync();
            return _mapper.Map<IEnumerable<MaintenanceRecordDto>>(records);
        }

        public async Task<MaintenanceRecordDto?> GetByIdAsync(int id)
        {
            var record = await _unitOfWork.MaintenanceRecords.GetByIdAsync(id);
            return record == null ? null : _mapper.Map<MaintenanceRecordDto>(record);
        }

        public async Task<MaintenanceRecordDto> CreateAsync(CreateMaintenanceRecordDto dto)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarId);
            if (car == null)
                throw new Exception("العربية غير موجودة");

            if (car.Status == CarStatus.Rented)
                throw new Exception("لا يمكن إدخال عربية مؤجرة حاليًا للصيانة");

            var record = _mapper.Map<MaintenanceRecord>(dto);

            car.Status = CarStatus.UnderMaintenance;
            _unitOfWork.Cars.Update(car);

            await _unitOfWork.MaintenanceRecords.AddAsync(record);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MaintenanceRecordDto>(record);
        }

        public async Task CompleteMaintenanceAsync(int id)
        {
            var record = await _unitOfWork.MaintenanceRecords.GetByIdAsync(id);
            if (record == null)
                throw new Exception("سجل الصيانة غير موجود");

            record.EndDate = DateTime.Now;
            _unitOfWork.MaintenanceRecords.Update(record);

            var car = await _unitOfWork.Cars.GetByIdAsync(record.CarId);
            car.Status = CarStatus.Available;
            _unitOfWork.Cars.Update(car);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
