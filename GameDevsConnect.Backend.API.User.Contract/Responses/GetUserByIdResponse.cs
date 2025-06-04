using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserByIdResponse(string message, bool status, UserModel myProperty)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public UserModel MyProperty { get; set; } = myProperty;
}
