using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Mappers;

public static class RequestMapper
{
    // Maps a RequestDto to a new RequestEntity
    public static RequestEntity ToEntity(RequestDto dto)
    {
        return new RequestEntity
        {
            InstitutionName = dto.InstitutionName,
            Description = dto.Description,
            NeedType = dto.NeedType,
            RequestedQuantity = dto.RequestedQuantity,
            Status = "Pending",
            Date = DateTime.Now
        };
    }
}
