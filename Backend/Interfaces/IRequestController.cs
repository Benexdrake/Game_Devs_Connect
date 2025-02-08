namespace Backend.Interfaces;

public interface IRequestController
{
    Task<ActionResult> GetRequests();
    Task<ActionResult> GetRequestById(string id);
    Task<ActionResult> AddRequest(Request request);
    Task<ActionResult> UpdateRequest(Request request);
    Task<ActionResult> DeleteRequest(string id);
}
