namespace Backend.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<string>> GetRequests();
    Task<APIResponse> GetRequestById(string id);
    Task<APIResponse> AddRequest(RequestTags rt);
    Task<APIResponse> UpdateRequest(Request request);
    Task<APIResponse> DeleteRequest(string id);
}
