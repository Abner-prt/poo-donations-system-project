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

        // Obtener todas las solicitudes completadas
        public async Task<List<RequestEntity>> GetCompletedAsync()
        {
            return await _context.Requests
                .Where(r => r.Status == "Completed")
                .ToListAsync();
        }

        // Crear una nueva solicitud
        public async Task<RequestEntity> CreateAsync(RequestDto dto)
        {
            // Validar campos vacios
            if (string.IsNullOrWhiteSpace(dto.InstitutionName) || string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new Exception("El nombre de la institucion y la descripcion no pueden estar vacios.");
            }

            // Validar cantidades logicas
            if (dto.RequestedQuantity <= 0)
            {
                throw new Exception("La cantidad solicitada debe ser mayor a 0.");
            }

            // Validar que el tipo de necesidad sea valido
            if (dto.NeedType != "Money" && dto.NeedType != "Item")
            {
                throw new Exception("El tipo de necesidad debe ser 'Money' o 'Item'");
            }

            // Prevenir peticiones duplicadas - Solo 1 solicitud pendiente permitida por institucion
            var hasPending = await _context.Requests.AnyAsync(r => r.InstitutionName == dto.InstitutionName && r.Status == "Pending");
            if (hasPending)
            {
                throw new Exception("Esta institucion ya cuenta con una solicitud activa en estado Pendiente. Debe ser completada antes de registrar otra.");
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
