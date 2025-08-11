namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserIdResponse(string message, bool status, string userId, string[] validateErrors = default!) : ApiResponse(message, status, validateErrors)
{
    public string Id { get; set; } = userId;
}
