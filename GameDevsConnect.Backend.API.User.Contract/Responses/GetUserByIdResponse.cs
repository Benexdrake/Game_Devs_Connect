namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserByIdResponse(string message, bool status, UserDTO user, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public UserDTO User { get; set; } = user;
}
