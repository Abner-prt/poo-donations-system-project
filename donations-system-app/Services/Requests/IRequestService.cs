using donations_system_app.Dtos.Requests;
using donations_system_app.Entities;

namespace donations_system_app.Services.Requests
{
    public interface IRequestService
    {
        Task<List<RequestEntity>> GetAllAsync();
        Task<List<RequestEntity>> GetCompletedAsync();
        Task<RequestEntity> CreateAsync(RequestDto dto);
        Task<RequestEntity> MarkAsCompletedAsync(int id);
    }
}
