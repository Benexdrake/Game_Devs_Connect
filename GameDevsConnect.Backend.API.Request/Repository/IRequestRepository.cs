namespace GameDevsConnect.Backend.API.Request.Repository;

public interface IRequestRepository
{
    Task<APIResponse> GetIdsAsync();
    Task<APIResponse> GetByIdAsync(string id);
    Task<APIResponse> GetFullByIdAsync(string id);
    Task<APIResponse> GetByUserIdAsync(string userId);
    Task<APIResponse> AddAsync(RequestModel request, TagModel[] tags);
    Task<APIResponse> UpdateAsync(RequestModel request);
    Task<APIResponse> DeleteAsync(string id);
}
