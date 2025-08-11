namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdsResponse(string message, bool status, string[] userIds, string[] errors = null!) : ApiResponse(message, status, errors)
{
    public string[] UserIds { get; set; } = userIds;
}
