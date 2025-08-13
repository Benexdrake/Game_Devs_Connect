namespace GameDevsConnect.Backend.API.Post.Services;

public class APIService(IPostRepository repo) : PostProtoService.PostProtoServiceBase
{
    private readonly IPostRepository _repo = repo;

    public override async Task<AddResponse> Add(UpsertPostRequest request, ServerCallContext context)
    {
        var addResponse = new AddResponse();
        var tags = new List<TagDTO>();

        var post = new PostDTO()
        {
            Id = request.Post.Id,
            Completed = request.Post.Completed,
            Created = DateTime.Parse(request.Post.Created),
            HasQuest = request.Post.HasQuest,
            IsDeleted = request.Post.IsDeleted,
            Message = request.Post.Message,
            OwnerId = request.Post.OwnerId,
            ParentId = request.Post.ParentId,
            ProjectId = request.Post.ProjectId
        };

        foreach (var tag in request.Tags)
            tags.Add(new TagDTO(tag.Tag_, tag.Type));

        var upsertPost = new UpsertPost(post, [.. tags], [.. request.FileIds]);

        var response = await _repo.AddAsync(upsertPost, context.CancellationToken);

        addResponse.Id = response.Id;
        addResponse.Respone.Message = response.Response.Message;
        addResponse.Respone.Status = response.Response.Status;
        addResponse.Respone.Errors.AddRange(response.Response.Errors);

        return addResponse;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteResponse = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Message = deleteResponse.Message;
        response.Status = deleteResponse.Status;
        response.Errors.AddRange(deleteResponse.Errors);

        return response;
    }

    public override async Task<GetPostResponse> GetById(IdRequest request, ServerCallContext context)
    {
        var getPostResponse = new GetPostResponse();

        var getResponse = await _repo.GetByIdAsync(request.Id, context.CancellationToken);

        getPostResponse.Post = new Post()
        {
            Id = getResponse.Post!.Id,
            Completed = getResponse.Post.Completed,
            Created = getResponse.Post.Created.ToString(),
            HasQuest = getResponse.Post.HasQuest,
            IsDeleted = getResponse.Post.IsDeleted,
            Message = getResponse.Post.Message,
            OwnerId = getResponse.Post.OwnerId,
            ParentId = getResponse.Post.ParentId,
            ProjectId = getResponse.Post.ProjectId
        };

        getPostResponse.Response.Message = getResponse.Response.Message;
        getPostResponse.Response.Status = getResponse.Response.Status;
        getPostResponse.Response.Errors.AddRange(getResponse.Response.Errors);

        return getPostResponse;
    }

    public override async Task<GetIdsResponse> GetByUserId(IdRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var idsResponse = await _repo.GetByUserIdAsync(request.Id, context.CancellationToken);

        getIdsResponse.Ids.AddRange(idsResponse.Ids);
        getIdsResponse.Response.Message = idsResponse.Response.Message;
        getIdsResponse.Response.Status = idsResponse.Response.Status;
        getIdsResponse.Response.Errors.AddRange(idsResponse.Response.Errors);

        return getIdsResponse;
    }

    public override async Task<GetIdsResponse> GetCommentIds(IdRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var idsResponse = await _repo.GetCommentIdsAsync(request.Id, context.CancellationToken);

        getIdsResponse.Ids.AddRange(idsResponse.Ids);
        getIdsResponse.Response.Message = idsResponse.Response.Message;
        getIdsResponse.Response.Status = idsResponse.Response.Status;
        getIdsResponse.Response.Errors.AddRange(idsResponse.Response.Errors);

        return getIdsResponse;
    }

    public override async Task<GetFullResponse> GetFull(IdRequest request, ServerCallContext context)
    {
        var getFullResponse = new GetFullResponse();

        var fullResponse = await _repo.GetFullByIdAsync(request.Id, context.CancellationToken);

        getFullResponse.Comments = fullResponse.Comments;
        getFullResponse.Likes = fullResponse.Likes;
        getFullResponse.QuestCount = fullResponse.QuestCount;
        getFullResponse.ProjectTitle = fullResponse.ProjectTitle;

        getFullResponse.Post = new Post()
        {
            Id = fullResponse.Post!.Id,
            Completed = fullResponse.Post.Completed,
            Created = fullResponse.Post.Created.ToString(),
            HasQuest = fullResponse.Post.HasQuest,
            IsDeleted = fullResponse.Post.IsDeleted,
            Message = fullResponse.Post.Message,
            OwnerId = fullResponse.Post.OwnerId,
            ParentId = fullResponse.Post.ParentId,
            ProjectId = fullResponse.Post.ProjectId
        };

        getFullResponse.Owner = new User()
        {
            Id = fullResponse.Owner!.Id,
            AccountType = fullResponse.Owner.Accounttype,
            Avatar = fullResponse.Owner.Avatar,
            LoginId = fullResponse.Owner.LoginId,
            Username = fullResponse.Owner.Username
        };

        foreach(var tag in fullResponse.Tags!)
        {
            getFullResponse.Tags.Add(new Tag() { Tag_ = tag.Tag, Type = tag.Type });
        }

        foreach(var file in fullResponse.Files)
        {
            getFullResponse.Files.Add(new File()
            {
                Id = file.Id,
                OwnerId = file.OwnerId,
                Created = file.Created.ToString(),
                Size = file.Size,
                Extension = file.Extension,
                Type = file.Type,
                Url = file.Url
            });
        }
        
        getFullResponse.Response.Message = fullResponse.Response.Message;
        getFullResponse.Response.Status = fullResponse.Response.Status;
        getFullResponse.Response.Errors.AddRange(fullResponse.Response.Errors);

        return getFullResponse;
    }

    public override async Task<GetIdsResponse> GetIds(GetPostIdsRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var getPostIdsRequest = new Contract.Request.GetPostIdsRequest(request.Page, request.PageSize, request.SearchTerm, request.ParentId);

        var idsResponse = await _repo.GetIdsAsync(getPostIdsRequest, context.CancellationToken);

        getIdsResponse.Ids.AddRange(idsResponse.Ids);
        getIdsResponse.Response.Message = idsResponse.Response.Message;
        getIdsResponse.Response.Status = idsResponse.Response.Status;
        getIdsResponse.Response.Errors.AddRange(idsResponse.Response.Errors);

        return getIdsResponse;
    }

    public override async Task<Response> Update(UpsertPostRequest request, ServerCallContext context)
    {
        var response = new Response();

        var tags = new List<TagDTO>();

        var post = new PostDTO()
        {
            Id = request.Post.Id,
            Completed = request.Post.Completed,
            Created = DateTime.Parse(request.Post.Created),
            HasQuest = request.Post.HasQuest,
            IsDeleted = request.Post.IsDeleted,
            Message = request.Post.Message,
            OwnerId = request.Post.OwnerId,
            ParentId = request.Post.ParentId,
            ProjectId = request.Post.ProjectId
        };

        foreach (var tag in request.Tags)
            tags.Add(new TagDTO(tag.Tag_, tag.Type));

        var upsertPost = new UpsertPost(post, [.. tags], [.. request.FileIds]);

        var updateResponse = await _repo.UpdateAsync(upsertPost, context.CancellationToken);
        
        response.Message = updateResponse.Message;
        response.Status = updateResponse.Status;
        response.Errors.AddRange(updateResponse.Errors);

        return response;
    }
}
