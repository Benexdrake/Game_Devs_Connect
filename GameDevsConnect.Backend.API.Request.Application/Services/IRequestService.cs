namespace GameDevsConnect.Backend.API.Request.Application.Services;

public interface IRequestService
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetByIdAsync(string id);
    Task<APIResponse> GetFullByIdAsync(string id);
    Task<APIResponse> GetByUserIdAsync(string userId);
    Task<APIResponse> AddAsync(AddRequest addRequest);
    Task<APIResponse> UpdateAsync(RequestModel request);
    Task<APIResponse> DeleteAsync(string id);
}
