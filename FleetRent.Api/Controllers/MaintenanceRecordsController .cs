using FleetRent.Application.DTOs.MaintenanceRecord;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.MaintenanceRecordService;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceRecordsController : ControllerBase
{
    private readonly IMaintenanceRecordService _service;

    public MaintenanceRecordsController(IMaintenanceRecordService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var record = await _service.GetByIdAsync(id);
        return record == null ? NotFound() : Ok(record);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMaintenanceRecordDto dto)
    {
        try { return Ok(await _service.CreateAsync(dto)); }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        try
        {
            await _service.CompleteMaintenanceAsync(id);
            return NoContent();
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}