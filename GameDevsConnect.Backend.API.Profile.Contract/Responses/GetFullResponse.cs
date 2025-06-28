namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetFullResponse(string message, bool status, UserDTO user, ProfileDTO profile) : ApiResponse(message, status)
{
    public UserDTO User { get; set; } = user;
    public ProfileDTO Profile { get; set; } = profile;
}
