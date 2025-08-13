namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdResponse(string message, bool status, string userId, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public string Id { get; set; } = userId;
}
