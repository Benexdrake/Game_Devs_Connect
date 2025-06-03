namespace GameDevsConnect.Backend.API.Request.Application.Repository;

public interface IRequestRepository
{
    Task<string[]> GetIdsAsync();
    Task<RequestModel> GetByIdAsync(string id);
    Task<GetFullResponse> GetFullByIdAsync(string id);
    Task<string[]> GetByUserIdAsync(string userId);
    Task<bool> AddAsync(AddRequest addRequest);
    Task<bool> UpdateAsync(RequestModel request);
    Task<bool> DeleteAsync(string id);
}
