using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Services;

// Interfaz para el servicio de donaciones
public interface IDonationService
{
    // Obtener todas las donaciones
    Task<IEnumerable<DonationEntity>> GetAllAsync();
    
    // Crear una nueva donacion
    Task<DonationEntity> CreateAsync(DonationDto donationDto);
    
    // Actualizar el estado de una donacion
    Task<bool> UpdateStatusAsync(int id, string newStatus);

    // Eliminar una donacion
    Task<bool> DeleteAsync(int id);
}
