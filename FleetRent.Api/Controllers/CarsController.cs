using FleetRent.Application.DTOs.Car;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;   // 👈 الـ Interface مش الكلاس

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null)
            return NotFound();

        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarDto dto)
    {
        var result = await _carService.CreateCarAsync(dto);
        return Ok(result);
    }
}