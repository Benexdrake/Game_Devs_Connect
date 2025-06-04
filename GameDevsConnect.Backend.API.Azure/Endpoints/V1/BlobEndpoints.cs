using Microsoft.AspNetCore.Mvc;

namespace GameDevsConnect.Backend.API.Azure.Endpoints.V1;
public static class BlobEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/azure/blob");

        group.MapGet("{fileName}/{containerName}", async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.GetBlobUrl(fileName, containerName);
        })
        .WithName("GetFileUrl")
        .Produces(StatusCodes.Status200OK);

        group.MapPost("add/{fileName}/{containerName}", async ([FromServices] IBlobRepository rep, IFormFile formFile, [FromRoute] string containerName, [FromRoute] string fileName) =>
        {
            return await rep.UploadBlob(formFile, containerName, fileName);
        })
        .WithName("UploadFile")
        .Accepts<IFormFile>("multipart/form-data")
        .Produces(StatusCodes.Status200OK);

        group.MapDelete("delete/{fileName}/{containerName}", async ([FromServices] IBlobRepository rep, [FromRoute] string fileName, [FromRoute] string containerName) =>
        {
            return await rep.RemoveBlob(fileName, containerName);
        })
        .WithName("DeleteFile")
        .Produces(StatusCodes.Status200OK);
    }
}
