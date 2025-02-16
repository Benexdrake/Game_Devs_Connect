namespace Backend.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<int>> GetRequests();
    Task<APIResponse> GetRequestById(int id);
    Task<APIResponse> AddRequest(RequestTags rt);
    Task<APIResponse> UpdateRequest(Request request);
    Task<APIResponse> DeleteRequest(int id);
}
