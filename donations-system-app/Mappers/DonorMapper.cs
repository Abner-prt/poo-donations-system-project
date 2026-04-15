using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Mappers;

public static class DonorMapper
{
    // Maps a DonorDto to a new DonorEntity
    public static DonorEntity ToEntity(DonorDto dto)
    {
        return new DonorEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Type = dto.Type,
            RegisteredAt = DateTime.Now
        };
    }
}
