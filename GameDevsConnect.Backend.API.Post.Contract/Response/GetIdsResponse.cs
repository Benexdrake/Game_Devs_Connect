using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Post.Contract.Response;

public class GetIdsResponse(string message, bool status, string[]? ids) : ApiResponse(message, status)
{
    public string[]? Ids { get; set; } = ids;
}