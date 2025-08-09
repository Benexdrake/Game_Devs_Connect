using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.User.Application.Validators;

namespace GameDevsConnect.Backend.API.User.Services;

public class UserRPCService(IUserRepository repo, GDCDbContext context) : UserProtoService.UserProtoServiceBase
{
    private readonly IUserRepository _repo = repo;
    private readonly GDCDbContext _context = context;

    public override async Task<UserId> Create(CreateUserRequest request, ServerCallContext context)
    {
        string id = "";

        UserDTO user = new (
            id: string.Empty,
            loginId: request.User.LoginId,
            username: request.User.Username,
            avatar: request.User.Avatar,
            accounttype: request.User.AccountType
            );

        var validation = await new UserValidation().Validate(_context, ValidationMode.Add, user, default);

        if(validation.Length == 0)
            id = await _repo.AddAsync(user);

        return new UserId() { Id = id};
    }

    public override async Task<Response> Update(UpdateUserRequest request, ServerCallContext context)
    {
        var response = new Response();
        UserDTO user = new ( 
            request.User.Id,
            request.User.LoginId,
            request.User.Username,
            request.User.Avatar,
            request.User.AccountType
            );

        var validation = await new UserValidation().Validate(_context, ValidationMode.Add, user, default);

        if (validation.Length == 0)
            response.Status = await _repo.UpdateAsync(user);

        return response;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response
        {
            Status = await _repo.DeleteAsync(request.Id)
        };

        return response;
    }

    public override async Task<GetUserIdsResponse> GetIds(Empty request, ServerCallContext context)
    {
        var response = new GetUserIdsResponse();

        var ids = await _repo.GetIdsAsync();

        response.Ids.AddRange(ids);

        return response;
    }

    public override async Task<User> Get(GetUserRequest request, ServerCallContext context)
    {
        var user = await _repo.GetAsync(request.Id) ?? new UserDTO(); 

        return new User()
        {
            Id = user.Id,
            LoginId = user.LoginId,
            Avatar = user.Avatar,
            AccountType = user.Accounttype,
            Username = user.Username
        };
    }

    public override async Task<Response> GetExist(IdRequest request, ServerCallContext context)
    {
        return new Response()
        {
            Status = await _repo.GetExistAsync(request.Id)
        };
    }

    public override async Task<GetUserIdsResponse> GetIdsByProjectId(IdRequest request, ServerCallContext context)
    {
        var ids = await _repo.GetIdsByProjectIdAsync(request.Id);

        var response = new GetUserIdsResponse();
        response.Ids.AddRange(ids);
        return response;
    }

    public override async Task<GetUserIdsResponse> GetFollowerIds(IdRequest request, ServerCallContext context)
    {
        var ids = await _repo.GetFollowerAsync(request.Id);

        var response = new GetUserIdsResponse();
        response.Ids.AddRange(ids);
        return response;
    }

    public override async Task<GetUserIdsResponse> GetFollowingIds(IdRequest request, ServerCallContext context)
    {
        var ids = await _repo.GetFollowingAsync(request.Id);

        var response = new GetUserIdsResponse();
        response.Ids.AddRange(ids);
        return response;
    }

    public override async Task<GetCountResponse> GetFollowerCount(IdRequest request, ServerCallContext context)
    {
        var count = await _repo.GetFollowerCountAsync(request.Id);

        return new GetCountResponse()
        {
            Count = count
        };
    }

    public override async Task<GetCountResponse> GetFollowingCount(IdRequest request, ServerCallContext context)
    {
        var count = await _repo.GetFollowingCountAsync(request.Id);

        return new GetCountResponse()
        {
            Count = count
        };
    }

}
