using FleetRent.Application.DTOs.Contract;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.ContractService;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    private readonly IContractService _contractService;

    public ContractsController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _contractService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contract = await _contractService.GetByIdAsync(id);
        return contract == null ? NotFound() : Ok(contract);
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> CheckOut(CheckOutDto dto)
    {
        try { return Ok(await _contractService.CheckOutCarAsync(dto)); }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("checkin")]
    public async Task<IActionResult> CheckIn(CheckInDto dto)
    {
        try { return Ok(await _contractService.CheckInCarAsync(dto)); }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}