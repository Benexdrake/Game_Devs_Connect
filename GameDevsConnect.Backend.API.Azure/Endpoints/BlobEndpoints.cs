namespace GameDevsConnect.Backend.API.Azure.Endpoints;
public static class BlobEndpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/azure/blob");

        group.MapGet("{fileName}/{containerName}", async (IBlobRepository rep, string fileName, string containerName) =>
        {
            return await rep.GetBlobUrl(fileName, containerName);
        });

        group.MapPost("{fileName}/{containerName}", async (IBlobRepository rep, IFormFile formFile, string containerName, string fileName) =>
        {
            return await rep.UploadBlob(formFile, containerName, fileName);
        });

        group.MapDelete("{fileName}/{containerName}", async (IBlobRepository rep, string fileName, string containerName) =>
        {
            return await rep.RemoveBlob(fileName, containerName);
        });
    }
}
