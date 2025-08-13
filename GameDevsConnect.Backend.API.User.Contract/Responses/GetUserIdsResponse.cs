namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdsResponse(string message, bool status, string[] userIds, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public string[] UserIds { get; set; } = userIds;
}
