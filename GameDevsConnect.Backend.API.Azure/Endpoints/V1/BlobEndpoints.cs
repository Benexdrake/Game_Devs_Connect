namespace GameDevsConnect.Backend.API.Azure.Endpoints.V1;
public static class BlobEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Tag.Group)
                       .WithApiVersionSet(apiVersionSet);

        group.MapGet(ApiEndpointsV1.Azure.Get, async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.GetBlobUrl(fileName, containerName);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Azure.Upload, async ([FromServices] IBlobRepository rep, IFormFile formFile, [FromRoute] string containerName, [FromRoute] string fileName) =>
        {
            return await rep.UploadBlob(formFile, containerName, fileName);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Upload)
        .Accepts<IFormFile>("multipart/form-data")
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Azure.Delete, async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.RemoveBlob(fileName, containerName);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
