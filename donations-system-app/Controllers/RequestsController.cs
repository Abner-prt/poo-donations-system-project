using Microsoft.AspNetCore.Mvc;
using donations_system_app.Dtos.Requests;
using donations_system_app.Services.Requests;

namespace donations_system_app.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // Registrar una nueva solicitud de institucion
        [HttpPost]
        public async Task<IActionResult> Create(RequestDto dto)
        {
            try
            {
                var result = await _requestService.CreateAsync(dto);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Ver solicitudes pendientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _requestService.GetAllAsync();
            return Ok(requests);
        }

        // Ver solicitudes completadas
        [HttpGet("completed")]
        public async Task<IActionResult> GetCompleted()
        {
            var requests = await _requestService.GetCompletedAsync();
            return Ok(requests);
        }

        // Marcar solicitud como completada
        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            try
            {
                var result = await _requestService.MarkAsCompletedAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
