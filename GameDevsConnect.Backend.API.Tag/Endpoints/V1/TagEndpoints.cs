namespace GameDevsConnect.Backend.API.Tag.Endpoints.V1;

public static class TagEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Tag.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Tag.GetAll, async ([FromServices] ITagRepository repo) =>
        {
            return await repo.GetAsync();
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.GetAll)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Tag.Create, async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.AddAsync(tag);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Tag.Update, async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.UpdateAsync(tag);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Tag.Delete, async ([FromServices] ITagRepository repo, [FromRoute] int id) =>
        {
            return await repo.DeleteAsync(id);
        })
            .WithName(ApiEndpointsV1.Tag.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
