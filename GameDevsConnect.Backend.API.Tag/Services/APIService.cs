using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.Tag.Services;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GameDevsConnect.Backend.API.User.Services;

public class APIService(ITagRepository repo, GDCDbContext context) : TagProtoService.TagProtoServiceBase
{
    private readonly ITagRepository _repo = repo;
    private readonly GDCDbContext _context = context;

    public override async Task<TagResponse> Get(Empty request, ServerCallContext context)
    {
        return await base.Get(request, context);
    }

    public override Task<Response> Add(TagRequest request, ServerCallContext context)
    {
        return base.Add(request, context);
    }

    public override Task<Response> Update(TagRequest request, ServerCallContext context)
    {
        return base.Update(request, context);
    }

    public override Task<Response> Delete(TagDeleteRequest request, ServerCallContext context)
    {
        return base.Delete(request, context);
    }
}
