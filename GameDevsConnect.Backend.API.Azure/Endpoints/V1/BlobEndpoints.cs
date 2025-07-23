using GameDevsConnect.Backend.API.Azure.Contract.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GameDevsConnect.Backend.API.Azure.Endpoints.V1;
public static class BlobEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Azure.GroupBlob)
                       .WithApiVersionSet(apiVersionSet);

        group.MapPost(ApiEndpointsV1.Azure.Get, async ([FromServices] IBlobRepository rep, [FromBody] BlobRequest request) =>
        {
            return await rep.GetBlobUrl(request.FileName, request.ContainerName);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Name.Get)
        .WithDescription(ApiEndpointsV1.Azure.MetaData.Description.Get)
        .Produces(StatusCodes.Status200OK);

        group.MapPost(ApiEndpointsV1.Azure.Upload, async (HttpRequest request, [FromServices] IBlobRepository rep) =>
        {
            return await rep.UploadBlob(request);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Name.Upload)
        .WithDescription(ApiEndpointsV1.Azure.MetaData.Description.Upload)
        .DisableAntiforgery()
        .Accepts<UploadFormRequest>("multipart/form-data")
        .Produces(StatusCodes.Status200OK);

        group.MapDelete(ApiEndpointsV1.Azure.Delete, async ([FromServices] IBlobRepository rep, [FromBody] BlobRequest request) =>
        {
            return await rep.RemoveBlob(request.FileName, request.ContainerName);
        })
        .WithName(ApiEndpointsV1.Azure.MetaData.Name.Delete)
        .WithDescription(ApiEndpointsV1.Azure.MetaData.Description.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}