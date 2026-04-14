using donations_system_app.Dtos;
using donations_system_app.Entities;

namespace donations_system_app.Services
{
    public interface IRequestService
    {
        Task<List<RequestEntity>> GetAllAsync();
        Task<RequestEntity> CreateAsync(RequestDto dto);
        Task<RequestEntity> MarkAsCompletedAsync(int id);
    }
}
