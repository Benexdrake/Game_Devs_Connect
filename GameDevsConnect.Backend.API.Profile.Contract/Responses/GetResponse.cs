using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetResponse(string message, bool status, ProfileModel profile)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public ProfileModel Profile { get; set; } = profile;
}