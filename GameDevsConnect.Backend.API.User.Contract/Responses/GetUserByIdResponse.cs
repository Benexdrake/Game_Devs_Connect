namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserByIdResponse(string message, bool status, UserDTO user) : ApiResponse(message, status)
{
    public UserDTO User { get; set; } = user;
}
