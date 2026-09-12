using FleetRent.Application.DTOs.Payment;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _paymentService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentDto dto) => Ok(await _paymentService.CreateAsync(dto));
}