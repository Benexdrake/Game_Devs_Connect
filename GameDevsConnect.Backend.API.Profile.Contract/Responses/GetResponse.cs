using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetResponse(string message, bool status, ProfileModel profile) : ApiResponse(message, status)
{
    public ProfileModel Profile { get; set; } = profile;
}