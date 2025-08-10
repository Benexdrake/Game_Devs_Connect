namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdResponse(string message, bool status, string userId) : ApiResponse(message, status)
{
    public string Id { get; set; } = userId;
}
