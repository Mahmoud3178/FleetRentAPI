using FleetRent.Application.DTOs.Booking;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _bookingService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        return booking == null ? NotFound() : Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingDto dto)
    {
        try { return Ok(await _bookingService.CreateBookingAsync(dto)); }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        try
        {
            await _bookingService.CancelBookingAsync(id);
            return NoContent();
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}