using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetUserByIdResponse(string message, bool status, UserModel myProperty) : ApiResponse(message, status)
{
    public UserModel MyProperty { get; set; } = myProperty;
}
