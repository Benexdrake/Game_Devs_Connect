namespace GameDevsConnect.Backend.API.User.Services;

public class APIService(IUserService service) : UserProtoService.UserProtoServiceBase
{
    private readonly IUserService _service = service;

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

        var sr = await _service.AddAsync(user);

        response.Id = sr.Id;
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
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

        var sr = await _service.UpdateAsync(user);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.ValidateErrors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var sr = await _service.DeleteAsync(request.Id);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.ValidateErrors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetIds(Empty request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _service.GetIdsAsync();

        response.Ids.AddRange(sr.UserIds);
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserResponse> Get(IdRequest request, ServerCallContext context)
    {
        var response = new UserResponse();

        var sr = await _service.GetAsync(request.Id);

        response.User = new User()
        {
            Id = sr.User.Id,
            LoginId = sr.User.LoginId,
            Avatar = sr.User.Avatar,
            AccountType = sr.User.Accounttype,
            Username = sr.User.Username
        };

        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<Response> GetExist(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var sr = await _service.GetExistAsync(request.Id);

        response.Message = sr.Message;
        response.Errors.AddRange(sr.ValidateErrors);
        response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetIdsByProjectId(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _service.GetIdsByProjectIdAsync(request.Id);

        response.Ids.AddRange(sr.UserIds);
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetFollowerIds(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _service.GetFollowerAsync(request.Id);

        response.Ids.AddRange(sr.UserIds);
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<UserIdsResponse> GetFollowingIds(IdRequest request, ServerCallContext context)
    {
        var response = new UserIdsResponse();

        var sr = await _service.GetFollowingAsync(request.Id);

        response.Ids.AddRange(sr.UserIds);
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<CountResponse> GetFollowerCount(IdRequest request, ServerCallContext context)
    {
        var response = new CountResponse();

        var sr = await _service.GetFollowerCountAsync(request.Id);

        response.Count = sr.Count;
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

    public override async Task<CountResponse> GetFollowingCount(IdRequest request, ServerCallContext context)
    {
        var response = new CountResponse();

        var sr = await _service.GetFollowingCountAsync(request.Id);

        response.Count = sr.Count;
        response.Response.Message = sr.Message;
        response.Response.Errors.AddRange(sr.ValidateErrors);
        response.Response.Status = sr.Status;

        return response;
    }

}
