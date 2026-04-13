using Microsoft.EntityFrameworkCore;
using donations_system_app.Data;
using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Services;

public class DonorService : IDonorService
{
    private readonly DonationsDbContext _context;

    public DonorService(DonationsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DonorEntity>> GetAllAsync()
    {
        return await _context.Donors.ToListAsync();
    }

    public async Task<DonorEntity> CreateAsync(DonorDto dto)
    {
        var donor = new DonorEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Type = dto.Type,
            RegisteredAt = DateTime.Now
        };

        _context.Donors.Add(donor);
        await _context.SaveChangesAsync();

        return donor;
    }
}
