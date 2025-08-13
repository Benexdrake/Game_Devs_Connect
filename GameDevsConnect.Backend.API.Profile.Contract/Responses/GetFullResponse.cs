namespace GameDevsConnect.Backend.API.Profile.Contract.Responses;

public class GetFullResponse(string message, bool status, UserDTO user, ProfileDTO profile, int followerCount, int followingCount, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public UserDTO User { get; set; } = user;
    public ProfileDTO Profile { get; set; } = profile;
    public int FollowerCount { get; set; } = followerCount;
    public int FollowingCount { get; set; } = followingCount;
}
