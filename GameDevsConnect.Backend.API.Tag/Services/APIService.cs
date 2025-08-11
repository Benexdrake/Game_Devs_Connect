namespace GameDevsConnect.Backend.API.User.Services;

public class APIService(ITagRepository repo) : TagProtoService.TagProtoServiceBase
{
    private readonly ITagRepository _repo = repo;

    public override async Task<TagResponse> Get(Empty request, ServerCallContext context)
    {
        var response = new TagResponse();

        var tagsResponse = await _repo.GetAsync(context.CancellationToken);

        response.Response = new();
        response.Response.Status = tagsResponse.Status;
        response.Response.Message = tagsResponse.Message;
        response.Response.Errors.AddRange(tagsResponse.Errors ?? []);

        foreach (var tag in tagsResponse.Tags)
            response.Tags.Add(new TagRequest() { Tag = tag.Tag, Type = tag.Type });
        
        return response;
    }

    public override async Task<Response> Add(TagRequest request, ServerCallContext context)
    {
        var response = new Response();

        var tagResponse = await _repo.AddAsync(new TagDTO(request.Tag, request.Type), context.CancellationToken);

        response.Status = tagResponse.Status;
        response.Message = tagResponse.Message;
        response.Errors.AddRange(tagResponse.Errors ?? []);
    
        return response;
    }

    public override async Task<Response> Update(TagRequest request, ServerCallContext context)
    {
        var response = new Response();

        var tagResponse = await _repo.UpdateAsync(new TagDTO(request.Tag, request.Type), context.CancellationToken);

        response.Status = tagResponse.Status;
        response.Message = tagResponse.Message;
        response.Errors.AddRange(tagResponse.Errors ?? []);

        return response;
    }

    public override async Task<Response> Delete(TagDeleteRequest request, ServerCallContext context)
    {
        var response = new Response();

        var tagResponse = await _repo.DeleteAsync(request.Tag, context.CancellationToken);

        response.Status = tagResponse.Status;
        response.Message = tagResponse.Message;
        response.Errors.AddRange(tagResponse.Errors ?? []);

        return response;
    }
}
