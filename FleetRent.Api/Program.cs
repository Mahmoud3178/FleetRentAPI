using FleetRent.Application.Interfaces;
using FleetRent.Application.Mapping;
using FleetRent.Application.Services;
using FleetRent.Application.Services.BookingService;
using FleetRent.Application.Services.BranchService;
using FleetRent.Application.Services.CarCategoryService;
using FleetRent.Application.Services.CarService;
using FleetRent.Application.Services.ContractService;
using FleetRent.Application.Services.MaintenanceRecordService;
using FleetRent.Application.Services.PaymentService;
using FleetRent.Application.Services.UserService;
using FleetRent.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext
            builder.Services.AddDbContext<FleetRentDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Unit of Work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<ICarCategoryService, CarCategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMaintenanceRecordService, MaintenanceRecordService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            // AutoMapper
            builder.Services.AddAutoMapper(cfg => { }, typeof(CarProfile));
            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}