using donations_system_app.Data;
using donations_system_app.Dtos;
using donations_system_app.Entities;
using donations_system_app.Mappers;
using Microsoft.EntityFrameworkCore;

namespace donations_system_app.Services;

// Implementacion del servicio de donaciones
public class DonationService : IDonationService
{
    private readonly DonationsDbContext _context;

    public DonationService(DonationsDbContext context)
    {
        _context = context;
    }

    // Listar todas las donaciones de la base de datos
    public async Task<IEnumerable<DonationEntity>> GetAllAsync()
    {
        return await _context.Donations.ToListAsync();
    }

    // Crear una nueva donacion validando el donante
    public async Task<DonationEntity> CreateAsync(DonationDto donationDto)
    {
        // Verificar si el donante existe por su ID
        var donorExists = await _context.Donors.AnyAsync(d => d.Id == donationDto.DonorId);
        
        if (!donorExists)
        {
            throw new Exception("El donante no existe");
        }

        // Crear la entidad usando el mapper
        var entity = DonationMapper.ToEntity(donationDto);

        // Guardar en base de datos
        _context.Donations.Add(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    // Actualizar estado de donacion con valores restringidos
    public async Task<bool> UpdateStatusAsync(int id, string newStatus)
    {
        // Validar que el estado sea permitido
        if (newStatus != "Available" && newStatus != "Delivered")
        {
            return false;
        }

        // Buscar donacion por su ID
        var donation = await _context.Donations.FindAsync(id);
        
        // Retornar falso si no existe
        if (donation == null)
        {
            return false;
        }

        // Actualizar el valor del estado
        donation.Status = newStatus;
        await _context.SaveChangesAsync();
        
        return true;
    }
}
