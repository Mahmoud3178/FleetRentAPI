using FleetRent.Application.DTOs.Branch;
using FleetRent.Application.Interfaces;
using FleetRent.Application.Services.BranchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchesController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var branches = await _branchService.GetAllBranchesAsync();
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _branchService.GetBranchByIdAsync(id);
        if (branch == null)
            return NotFound();

        return Ok(branch);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchDto dto)
    {
        var result = await _branchService.CreateBranchAsync(dto);
        return Ok(result);
    }
}