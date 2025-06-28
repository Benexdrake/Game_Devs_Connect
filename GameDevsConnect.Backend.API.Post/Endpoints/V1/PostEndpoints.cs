namespace GameDevsConnect.Backend.API.Post.Endpoints.V1;

public static class PostEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Post.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Post.Get, async ([FromServices] IPostRepository repo) =>
        {
            return await repo.GetIdsAsync();
        })
            .WithName(ApiEndpointsV1.Post.MetaData.Get)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetById, async ([FromServices] IPostRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.GetById)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetFull, async ([FromServices] IPostRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetFullByIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.GetFull)
            .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Post.GetByUserId, async ([FromServices] IPostRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByUserIdAsync(id);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.GetByUserId)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Post.Create, async ([FromServices] IPostRepository repo, [FromBody] AddPost add) =>
        {
            return await repo.AddAsync(add);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Post.Update, async ([FromServices] IPostRepository repo, [FromBody] PostDTO Post) =>
        {
            return await repo.UpdateAsync(Post);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Post.Delete, async ([FromServices] IPostRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        })
            .WithName(ApiEndpointsV1.Post.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
