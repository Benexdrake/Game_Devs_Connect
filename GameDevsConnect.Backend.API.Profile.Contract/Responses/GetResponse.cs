using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetResponse(string message, bool status, ProfileDTO profile) : ApiResponse(message, status)
{
    public ProfileDTO Profile { get; set; } = profile;
}