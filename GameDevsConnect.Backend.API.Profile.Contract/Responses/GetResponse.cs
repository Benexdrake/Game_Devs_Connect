namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetResponse(string message, bool status, ProfileDTO profile, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public ProfileDTO Profile { get; set; } = profile;
}