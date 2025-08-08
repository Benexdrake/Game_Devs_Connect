using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.User.Application.Validators;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GameDevsConnect.Backend.API.User.gRPC.Services;

public class UserRPCService(IUserRepository repo, GDCDbContext context) : UserProtoService.UserProtoServiceBase
{
    private readonly IUserRepository _repo = repo;
    private readonly GDCDbContext _context = context;

    public override async Task<UserId> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        string id = "";

        UserDTO user = new()
        {
            Id = string.Empty,
            LoginId = request.User.LoginId,
            Avatar = request.User.Avatar,
            Accounttype = request.User.AccountType,
            Username = request.User.Username
        };

        var validation = await new UserValidation().Validate(_context, ValidationMode.Add, user, default);

        if(validation.Length == 0)
            id = await _repo.AddAsync(user);

        return new UserId() { Id = id};
    }

    public override async Task<Response> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        var response = new Response();
        UserDTO user = new()
        {
            Id = request.User.Id,
            LoginId = request.User.LoginId,
            Avatar = request.User.Avatar,
            Accounttype = request.User.AccountType,
            Username = request.User.Username
        };
        response.Status = await _repo.UpdateAsync(user);

        return response;
    }

    public override async Task<Response> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        var response = new Response
        {
            Status = await _repo.DeleteAsync(request.Id)
        };

        return response;
    }

    public override async Task<GetUserIdsResponse> GetUserIds(Empty request, ServerCallContext context)
    {
        var response = new GetUserIdsResponse();

        var ids = await _repo.GetIdsAsync();

        response.Ids.AddRange(ids);

        return response;
    }
}
