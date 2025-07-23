namespace GameDevsConnect.Backend.API.Tag.Endpoints.V1;

public static class TagEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Tag.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Tag.GetAll, async ([FromServices] ITagRepository repo, CancellationToken token) =>
        {
            return await repo.GetAsync(token);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Name.GetAll)
            .WithDescription(ApiEndpointsV1.Tag.MetaData.Description.GetAll)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Tag.Create, async ([FromServices] ITagRepository repo, [FromBody] TagDTO tag, CancellationToken token) =>
        {
            return await repo.AddAsync(tag, token);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Name.Create)
            .WithDescription(ApiEndpointsV1.Tag.MetaData.Description.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Tag.Update, async ([FromServices] ITagRepository repo, [FromBody] TagDTO tag, CancellationToken token) =>
        {
            return await repo.UpdateAsync(tag, token);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Name.Update)
            .WithDescription(ApiEndpointsV1.Tag.MetaData.Description.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Tag.Delete, async ([FromServices] ITagRepository repo, [FromRoute] string tag, CancellationToken token) =>
        {
            return await repo.DeleteAsync(tag, token);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Name.Delete)
            .WithDescription(ApiEndpointsV1.Tag.MetaData.Description.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
