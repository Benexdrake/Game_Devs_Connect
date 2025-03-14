namespace Backend.Interfaces;

public interface IRequestRepository
{
    Task<APIResponse> GetRequests();
    Task<APIResponse> GetRequestById(int id);
    Task<APIResponse> GetRequestsByUserId(string userId);
    Task<APIResponse> AddRequest(RequestTags rt);
    Task<APIResponse> UpdateRequest(Request request);
    Task<APIResponse> DeleteRequest(int id);
    Task<APIResponse> getFullRequestById(int id, string userId);
    Task<APIResponse> LikesOnRequest(int requestId, string userId, bool liked);
}
