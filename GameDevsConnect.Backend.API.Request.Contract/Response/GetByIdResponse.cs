using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Request.Contract.Response;
public class GetByIdResponse(string message, bool status, RequestModel? request)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public RequestModel? Request { get; set; } = request;
}
