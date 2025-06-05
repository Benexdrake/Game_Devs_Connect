using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetFullResponse(string message, bool status, UserModel user, ProfileModel profile) : ApiResponse(message, status)
{
    public UserModel User { get; set; } = user;
    public ProfileModel Profile { get; set; } = profile;
}
