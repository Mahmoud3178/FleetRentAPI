using FleetRent.Application.DTOs.CarCategory;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.CarCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarCategoriesController : ControllerBase
{
    private readonly ICarCategoryService _carCategoryService;

    public CarCategoriesController(ICarCategoryService carCategoryService)
    {
        _carCategoryService = carCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _carCategoryService.GetAllCarCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _carCategoryService.GetCarCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCategoryDto dto)
    {
        var result = await _carCategoryService.CreateCarCategoryAsync(dto);
        return Ok(result);
    }
}
