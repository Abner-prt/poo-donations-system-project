using Microsoft.EntityFrameworkCore;
using donations_system_app.Data;
using donations_system_app.Dtos;
using donations_system_app.Entities;
using donations_system_app.Mappers;

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
        // No repetir Email
        var emailExists = await _context.Donors.AnyAsync(d => d.Email == dto.Email);
        if (emailExists)
        {
            throw new Exception("Este correo electronico ya se encuentra registrado.");
        }

        // No repetir Telefono
        var phoneExists = await _context.Donors.AnyAsync(d => d.Phone == dto.Phone);
        if (phoneExists)
        {
            throw new Exception("Este numero de telefono ya se encuentra registrado.");
        }

        var donor = DonorMapper.ToEntity(dto);

        _context.Donors.Add(donor);
        await _context.SaveChangesAsync();

        return donor;
    }
}
