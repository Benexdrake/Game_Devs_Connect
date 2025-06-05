using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdsResponse(string message, bool status, string[] userIds) : ApiResponse(message, status)
{
    public string[] UserIds { get; set; } = userIds;
}
