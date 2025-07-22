namespace GameDevsConnect.Backend.API.File.Endpoints.V1;

public static class FileEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.File.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.File.GetByOwnerId, async ([FromServices] IFileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetIdsByOwnerIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Name.GetByOwnerId)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.File.Get, async ([FromServices] IFileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetByIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Name.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.File.Create, async ([FromServices] IFileRepository rep, [FromBody] FileDTO File, CancellationToken token) =>
        {
            return await rep.AddAsync(File, token);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Name.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.File.Update, async ([FromServices] IFileRepository rep, [FromBody] FileDTO File, CancellationToken token) =>
        {
            return await rep.UpdateAsync(File, token);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Name.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.File.Delete, async ([FromServices] IFileRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Name.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
