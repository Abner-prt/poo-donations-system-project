using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Mappers;

public static class DonationMapper
{
    // Maps a DonationDto to a new DonationEntity
    public static DonationEntity ToEntity(DonationDto dto)
    {
        return new DonationEntity
        {
            DonorId = dto.DonorId,
            Type = dto.Type,
            Description = dto.Description,
            Quantity = dto.Quantity,
            Status = "Available",
            Date = DateTime.UtcNow
        };
    }
}
