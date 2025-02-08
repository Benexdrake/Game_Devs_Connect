namespace Backend.Interfaces;

public interface IRequestRepository
{
    Task<IEnumerable<Request>> GetRequests();
    Task<Request> GetRequestById(string id);
    Task<bool> AddRequest(Request request);
    Task<bool> UpdateRequest(Request request);
    Task<bool> DeleteRequest(string id);
}
