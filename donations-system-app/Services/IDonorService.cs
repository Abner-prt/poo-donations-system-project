using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Services;

public interface IDonorService
{
    Task<IEnumerable<DonorEntity>> GetAllAsync();
    Task<DonorEntity> CreateAsync(DonorDto dto);
}
