namespace GameDevsConnect.Backend.API.User.Services;

public class APIService(IUserRepository repo) : UserProtoService.UserProtoServiceBase
{
    private readonly IUserRepository _repo = repo;

    public override async Task<UserIdResponse> Create(UserRequest request, ServerCallContext context)
    {
        var response = new UserIdResponse();

        UserDTO user = new (
            id: string.Empty,
            loginId: request.User.LoginId,
            username: request.User.Username,
            avatar: request.User.Avatar,
            accounttype: request.User.AccountType
            );

        var sr = await _repo.AddAsync(user, context.CancellationToken);

        response.Id = sr.Id;
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<Response> Update(UserRequest request, ServerCallContext context)
    {
        var response = new Response();
        UserDTO user = new(
            request.User.Id,
            request.User.LoginId,
            request.User.Username,
            request.User.Avatar,
            request.User.AccountType
            );

        var sr = await _repo.UpdateAsync(user, context.CancellationToken);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.Errors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var sr = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.Errors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetIds(Empty request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _repo.GetIdsAsync(context.CancellationToken);

        response.Ids.AddRange(sr.UserIds);
        response.Response = new ();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserResponse> Get(IdRequest request, ServerCallContext context)
    {
        var response = new UserResponse();

        var sr = await _repo.GetAsync(request.Id, context.CancellationToken);

        response.User = new User()
        {
            Id = sr.User.Id,
            LoginId = sr.User.LoginId,
            Avatar = sr.User.Avatar,
            AccountType = sr.User.Accounttype,
            Username = sr.User.Username
        };

        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<Response> GetExist(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var sr = await _repo.GetExistAsync(request.Id, context.CancellationToken);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.Errors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetIdsByProjectId(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _repo.GetIdsByProjectIdAsync(request.Id, context.CancellationToken);

        response.Ids.AddRange(sr.UserIds);
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetFollowerIds(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _repo.GetFollowerAsync(request.Id, context.CancellationToken);

        response.Ids.AddRange(sr.UserIds);
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetFollowingIds(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _repo.GetFollowingAsync(request.Id, context.CancellationToken);

        response.Ids.AddRange(sr.UserIds);
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<CountResponse> GetFollowerCount(IdRequest request, ServerCallContext context)
    {
        var response = new CountResponse();

        var sr = await _repo.GetFollowerCountAsync(request.Id, context.CancellationToken);

        response.Count = sr.Count;
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<CountResponse> GetFollowingCount(IdRequest request, ServerCallContext context)
    {
        var response = new CountResponse();

        var sr = await _repo.GetFollowingCountAsync(request.Id, context.CancellationToken);

        response.Count = sr.Count;
        response.Response = new();
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.Errors ?? []);
        response.Response.Status = sr.Status;

        return response;
    }

}
