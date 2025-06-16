namespace GameDevsConnect.Backend.API.File.Endpoints.V1;

public static class FileEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Tag.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.File.GetByOwnerId, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetIdsByOwnerIdAsync(id);
        })
        .WithName(ApiEndpointsV1.File.MetaData.GetByOwnerId)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.File.Get, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByIdAsync(id);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapGet(ApiEndpointsV1.File.GetByRequestId, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
        {
            return await rep.GetByRequestIdAsync(id);
        })
        .WithName(ApiEndpointsV1.File.MetaData.GetByRequestId)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.File.Create, async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
        {
            return await rep.AddAsync(File);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Create)
        .Produces(StatusCodes.Status200OK);

        group.MapPut(ApiEndpointsV1.File.Update, async ([FromServices] IFileRepository rep, [FromBody] FileModel File) =>
        {
            return await rep.UpdateAsync(File);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Update)
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.File.Delete, async ([FromServices] IFileRepository rep, [FromRoute] string id) =>
        {
            return await rep.DeleteAsync(id);
        })
        .WithName(ApiEndpointsV1.File.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
