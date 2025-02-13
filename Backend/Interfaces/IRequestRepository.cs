namespace Backend.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<string>> GetRequests();
    Task<APIResponse> GetRequestById(string id);
    Task<APIResponse> AddRequest(Request request);
    Task<APIResponse> UpdateRequest(Request request);
    Task<APIResponse> DeleteRequest(string id);
}
