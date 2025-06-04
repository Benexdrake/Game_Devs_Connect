namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdsResponse(string message, bool status, string[] userIds)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[] UserIds { get; set; } = userIds;
}
