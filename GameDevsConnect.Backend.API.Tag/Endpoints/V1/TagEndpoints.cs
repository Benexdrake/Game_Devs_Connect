using GameDevsConnect.Backend.API.Configuration;

namespace GameDevsConnect.Backend.API.Tag.Endpoints.V1;

public static class TagEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.Tag.Group);

        group.MapGet(ApiEndpoints.Tag.GetAll, async ([FromServices] ITagRepository repo) =>
        {
            return await repo.GetAsync();
        })
            .WithName(ApiEndpoints.Tag.MetaData.GetAll)
            .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.Tag.Create, async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.AddAsync(tag);
        })
            .WithName(ApiEndpoints.Tag.MetaData.Create)
            .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpoints.Tag.Update, async ([FromServices] ITagRepository repo, [FromBody] TagModel tag) =>
        {
            return await repo.UpdateAsync(tag);
        })
            .WithName(ApiEndpoints.Tag.MetaData.Update)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.Tag.Delete, async ([FromServices] ITagRepository repo, [FromRoute] int id) =>
        {
            return await repo.DeleteAsync(id);
        })
            .WithName(ApiEndpoints.Tag.MetaData.Delete)
            .Produces(StatusCodes.Status200OK);
    }
}
