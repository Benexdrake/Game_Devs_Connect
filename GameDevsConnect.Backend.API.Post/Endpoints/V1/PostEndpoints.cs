namespace GameDevsConnect.Backend.API.Post.Endpoints.V1;

public static class PostEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Post.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Post.Get, async ([FromServices] IPostRepository repo, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string searchTerm = "", [FromQuery] string parentId = "",  CancellationToken token = default) =>
        {
            return await repo.GetIdsAsync(new GetPostIdsRequest(page, pageSize, searchTerm, parentId), token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetById, async ([FromServices] IPostRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetByIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.GetById)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetFull, async ([FromServices] IPostRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetFullByIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.GetFull)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetByUserId, async ([FromServices] IPostRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetByUserIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.GetByUserId)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetCommentByParentId, async ([FromServices] IPostRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetCommentIdsAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.GetCommentByParentId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Post.Create, async ([FromServices] IPostRepository repo, [FromBody] UpsertPost add, CancellationToken token) =>
        {
            return await repo.AddAsync(add, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Post.Update, async ([FromServices] IPostRepository repo, [FromBody] UpsertPost updatePost, CancellationToken token) =>
        {
            return await repo.UpdateAsync(updatePost, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Post.Delete, async ([FromServices] IPostRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Post.MetaData.Name.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
