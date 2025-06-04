namespace GameDevsConnect.Backend.API.Request.Application.Repository.V1;

public interface IRequestRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetByIdResponse> GetByIdAsync(string id);
    Task<GetFullResponse> GetFullByIdAsync(string id);
    Task<GetIdsResponse> GetByUserIdAsync(string userId);
    Task<AddUpdateDeleteRequestResponse> AddAsync(AddRequest addRequest);
    Task<AddUpdateDeleteRequestResponse> UpdateAsync(RequestModel request);
    Task<AddUpdateDeleteRequestResponse> DeleteAsync(string id);
}
