using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetFullResponse(string message, bool status, UserModel user, ProfileModel profile)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public UserModel User { get; set; } = user;
    public ProfileModel Profile { get; set; } = profile;
}
