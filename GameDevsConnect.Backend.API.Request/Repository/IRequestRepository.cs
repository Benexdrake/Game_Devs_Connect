namespace GameDevsConnect.Backend.API.Request.Repository;

public interface IRequestRepository
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetByIdAsync(int id);
    Task<APIResponse> GetByUserIdAsync(string userId);
    Task<APIResponse> AddAsync(RequestModel request);
    Task<APIResponse> UpdateAsync(RequestModel request);
    Task<APIResponse> DeleteAsync(int id);
}
