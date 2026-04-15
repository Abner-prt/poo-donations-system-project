using Microsoft.AspNetCore.Mvc;
using donations_system_app.Services;
using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Controllers;

// Controlador para gestionar las donaciones
[ApiController]
[Route("api/[controller]")]
public class DonationsController : ControllerBase
{
    private readonly IDonationService _donationService;

    // Inyectar el servicio de donaciones
    public DonationsController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    // POST /api/donations - Registrar una nueva donacion
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DonationDto donationDto)
    {
        try
        {
            var result = await _donationService.CreateAsync(donationDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Retornar error si algo sale mal (ej. donante no existe)
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET /api/donations - Ver todas las donaciones registradas
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _donationService.GetAllAsync();
        return Ok(result);
    }

    // PUT /api/donations/{id} - Actualizar el estado de una donacion
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
    {
        var result = await _donationService.UpdateStatusAsync(id, newStatus);
        
        if (!result)
        {
            // Retornar error si el estado es invalido o la donacion no existe
            return BadRequest(new { message = "No se pudo actualizar el estado o el valor no es permitido" });
        }
        
        return Ok(new { message = "Estado actualizado correctamente" });
    }
}
