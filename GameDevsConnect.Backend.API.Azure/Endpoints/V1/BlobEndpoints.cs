using GameDevsConnect.Backend.API.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace GameDevsConnect.Backend.API.Azure.Endpoints.V1;
public static class BlobEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiEndpoints.Azure.GroupBlob);

        group.MapGet(ApiEndpoints.Azure.Get, async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.GetBlobUrl(fileName, containerName);
        })
        .WithName(ApiEndpoints.Azure.MetaData.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpoints.Azure.Upload, async ([FromServices] IBlobRepository rep, IFormFile formFile, [FromRoute] string containerName, [FromRoute] string fileName) =>
        {
            return await rep.UploadBlob(formFile, containerName, fileName);
        })
        .WithName(ApiEndpoints.Azure.MetaData.Upload)
        .Accepts<IFormFile>("multipart/form-data")
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpoints.Azure.Delete, async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.RemoveBlob(fileName, containerName);
        })
        .WithName(ApiEndpoints.Azure.MetaData.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
