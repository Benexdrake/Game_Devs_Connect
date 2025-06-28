namespace GameDevsConnect.Backend.API.Project.Endpoints.V1;
public static class ProjectEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Project.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Project.Get, async ([FromServices] IProjectRepository repo, CancellationToken token) =>
        {
            return await repo.GetIdsAsync(token);
        })
        .WithName(ApiEndpointsV1.Project.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.Project.GetByRequestId, async ([FromServices] IProjectRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.GetByIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Project.MetaData.GetByRequestId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Project.Create, async ([FromServices] IProjectRepository repo, [FromBody] UpsertProject addRequest, CancellationToken token) =>
        {
            return await repo.AddAsync(addRequest, token);
        })
        .WithName(ApiEndpointsV1.Project.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.Project.Update, async ([FromServices] IProjectRepository repo, [FromBody] UpsertProject updateRequest, CancellationToken token) =>
        {
            return await repo.UpdateAsync(updateRequest, token);
        })
        .WithName(ApiEndpointsV1.Project.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Project.Delete, async ([FromServices] IProjectRepository repo, [FromRoute] string id, CancellationToken token) =>
        {
            return await repo.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Project.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
