namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserByIdResponse(string message, bool status, UserDTO myProperty) : ApiResponse(message, status)
{
    public UserDTO MyProperty { get; set; } = myProperty;
}
