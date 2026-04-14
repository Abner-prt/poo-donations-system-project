using Microsoft.AspNetCore.Mvc;
using donations_system_app.Dtos;
using donations_system_app.Services;

namespace donations_system_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorsController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    // GET: api/donors
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var donors = await _donorService.GetAllAsync();
        return Ok(donors);
    }

    // POST: api/donors
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DonorDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Donor data cannot be null.");
        }

        var donor = await _donorService.CreateAsync(dto);
        
        // Return 201 Created status
        return StatusCode(StatusCodes.Status201Created, donor);
    }
}
