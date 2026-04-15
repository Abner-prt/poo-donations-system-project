using Microsoft.EntityFrameworkCore;
using donations_system_app.Data;
using donations_system_app.Dtos;
using donations_system_app.Entities;
using donations_system_app.Mappers;

namespace donations_system_app.Services
{
    public class RequestService : IRequestService
    {
        private readonly DonationsDbContext _context;

        public RequestService(DonationsDbContext context)
        {
            _context = context;
        }

        // Obtener todas las solicitudes pendientes
        public async Task<List<RequestEntity>> GetAllAsync()
        {
            return await _context.Requests
                .Where(r => r.Status == "Pending")
                .ToListAsync();
        }

        // Crear una nueva solicitud
        public async Task<RequestEntity> CreateAsync(RequestDto dto)
        {
            // Validar que el tipo de necesidad sea valido
            if (dto.NeedType != "Money" && dto.NeedType != "Item")
            {
                throw new Exception("El tipo de necesidad debe ser 'Money' o 'Item'");
            }

            var request = RequestMapper.ToEntity(dto);

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }

        // Marcar una solicitud como completada
        public async Task<RequestEntity> MarkAsCompletedAsync(int id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                throw new Exception("No se encontro la solicitud");
            }

            // Validar que la solicitud no este ya completada
            if (request.Status == "Completed")
            {
                throw new Exception("Esta solicitud ya fue completada");
            }

            request.Status = "Completed";
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
