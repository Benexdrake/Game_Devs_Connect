namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetResponse(string message, bool status, ProfileModel profile) : ApiResponse(message, status)
{
    public ProfileModel Profile { get; set; } = profile;
}