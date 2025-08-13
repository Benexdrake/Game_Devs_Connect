namespace GameDevsConnect.Backend.API.Profile.Services;

public class APIService(IProfileRepository repo) : ProfileProtoService.ProfileProtoServiceBase
{
    private readonly IProfileRepository _repo = repo;

    public override async Task<Response> Add(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var addResponse = await _repo.AddAsync(request.Id, context.CancellationToken);

        response.Status = addResponse.Status;
        response.Message = addResponse.Message;
        response.Errors.AddRange(addResponse.Errors);

        return response;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteResponse = await _repo.DeleteAsync(request.Id,context.CancellationToken);

        response.Status = deleteResponse.Status;
        response.Message = deleteResponse.Message;
        response.Errors.AddRange(deleteResponse.Errors);

        return response;
    }

    public override async Task<Response> Update(Profile request, ServerCallContext context)
    {
        var response = new Response();

        var profile = new ProfileDTO()
        {
            Id = request.Id,
            DiscordUrl = request.DiscordUrl,
            ShowDiscord = request.ShowDiscord,
            Email = request.Email,
            ShowEmail = request.ShowEmail,
            ShowWebsite = request.ShowWebsite,
            ShowX = request.ShowX,
            UserId = request.UserId,
            WebsiteUrl = request.WebsiteUrl,
            XUrl = request.XUrl
        };

        var updateResponse = await _repo.UpdateAsync(profile, context.CancellationToken);

        response.Status = updateResponse.Status;
        response.Message = updateResponse.Message;
        response.Errors.AddRange(updateResponse.Errors);

        return response;
    }

    public override async Task<GetResponse> Get(IdRequest request, ServerCallContext context)
    {
        var getResponse = new GetResponse();

        var getProfileResponse = await _repo.GetAsync(request.Id, context.CancellationToken);

        getResponse.Profile = new Profile()
        {
            Id = getProfileResponse.Profile.Id,
            DiscordUrl = getProfileResponse.Profile.DiscordUrl,
            ShowDiscord = getProfileResponse.Profile.ShowDiscord,
            Email = getProfileResponse.Profile.Email,
            ShowEmail = getProfileResponse.Profile.ShowEmail,
            ShowWebsite = getProfileResponse.Profile.ShowWebsite,
            ShowX = getProfileResponse.Profile.ShowX,
            UserId = getProfileResponse.Profile.UserId,
            WebsiteUrl = getProfileResponse.Profile.WebsiteUrl,
            XUrl = getProfileResponse.Profile.XUrl
        };
        
        getResponse.Response.Status = getProfileResponse.Response.Status;
        getResponse.Response.Message = getProfileResponse.Response.Message;
        getResponse.Response.Errors.AddRange(getProfileResponse.Response.Errors);


        return getResponse;
    }

    public override async Task<GetFullResponse> GetFull(IdRequest request, ServerCallContext context)
    {
        var getFullResponse = new GetFullResponse();

        var response = await _repo.GetFullAsync(request.Id, context.CancellationToken);

        getFullResponse.Profile = new Profile()
        {
            Id = response.Profile.Id,
            DiscordUrl = response.Profile.DiscordUrl,
            ShowDiscord = response.Profile.ShowDiscord,
            Email = response.Profile.Email,
            ShowEmail = response.Profile.ShowEmail,
            ShowWebsite = response.Profile.ShowWebsite,
            ShowX = response.Profile.ShowX,
            UserId = response.Profile.UserId,
            WebsiteUrl = response.Profile.WebsiteUrl,
            XUrl = response.Profile.XUrl
        };

        getFullResponse.User = new User()
        {
            Id = response.User.Id,
            LoginId = response.User.LoginId,
            AccountType = response.User.Accounttype,
            Avatar = response.User.Avatar,
            Username = response.User.Username
        };

        getFullResponse.FollowerCount = response.FollowerCount;
        getFullResponse.FollowingCount = response.FollowingCount;

        getFullResponse.Response.Message = response.Response.Message;
        getFullResponse.Response.Status = response.Response.Status;
        getFullResponse.Response.Errors.AddRange(response.Response.Errors);

        return getFullResponse;
    }
}