namespace GameDevsConnect.Backend.API.Request.Application.Repository.V1;

public interface IRequestRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetByIdResponse> GetByIdAsync(string id);
    Task<GetFullResponse> GetFullByIdAsync(string id);
    Task<GetIdsResponse> GetByUserIdAsync(string userId);
    Task<ApiResponse> AddAsync(AddRequest addRequest);
    Task<ApiResponse> UpdateAsync(RequestModel request);
    Task<ApiResponse> DeleteAsync(string id);
}
