namespace GameDevsConnect.Backend.API.Project.Endpoints.V1;
public static class ProjectEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.Project.Group);

        group.MapGet(ApiEndpoints.Project.Get, async ([FromServices] IProjectRepository repo) =>
        {
            return await repo.GetIdsAsync();
        })
        .WithName(ApiEndpoints.Project.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpoints.Project.GetByRequestId, async ([FromServices] IProjectRepository repo, [FromRoute] string id) =>
        {
            return await repo.GetByIdAsync(id);
        })
        .WithName(ApiEndpoints.Project.MetaData.GetByRequestId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.Project.Create, async ([FromServices] IProjectRepository repo, [FromBody] UpsertRequest addRequest) =>
        {
            return await repo.AddAsync(addRequest);
        })
        .WithName(ApiEndpoints.Project.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpoints.Project.Update, async ([FromServices] IProjectRepository repo, [FromBody] UpsertRequest updateRequest) =>
        {
            return await repo.UpdateAsync(updateRequest);
        })
        .WithName(ApiEndpoints.Project.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.Project.Delete, async ([FromServices] IProjectRepository repo, [FromRoute] string id) =>
        {
            return await repo.DeleteAsync(id);
        })
        .WithName(ApiEndpoints.Project.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
