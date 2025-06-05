using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Request.Contract.Response;

public class GetIdsResponse(string message, bool status, string[]? ids) : ApiResponse(message, status)
{
    public string[]? Ids { get; set; } = ids;
}