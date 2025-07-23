using GameDevsConnect.Backend.API.Azure.Contract.Requests;
using System.Text.Json;

namespace GameDevsConnect.Backend.API.Azure.Application.Repository.V1;
public class BlobRepository(IBlobStorageService service) : IBlobRepository
{
    private readonly IBlobStorageService _service = service;

    public async Task<GetResponse> GetBlobUrl(string fileName, string containerName)
    {
        try
        {
            var (url, status) = await _service.GetBlobUrl(fileName, containerName);

            if (!status)
            {
                Log.Error(url);
                return new GetResponse(url, false, null!);
            }

            return new GetResponse(null!, true, url);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UploadBlob(HttpRequest request)
    {
        try
        {
            var blobRequest = await GetRequest(request);
            if(blobRequest is null)
            {
                Log.Error("Something was missing");
                return new ApiResponse(null!, false, null!);
            }

            var (result, status) = await _service.UploadBlob(blobRequest.FormFile, blobRequest.ContainerName, blobRequest.FileName);

            if (!status)
            {
                Log.Error(result);
                return new ApiResponse(result, false);
            }

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> RemoveBlob(string fileName, string containerName)
    {
        try
        {
            var (result, status) = await _service.RemoveBlob(fileName, containerName);

            if (!status)
            {
                Log.Error(result);
                return new ApiResponse(result, false);
            }

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    private async Task<BlobRequest> GetRequest(HttpRequest request)
    {
        var form = await request.ReadFormAsync();

        var file = form.Files.GetFile("formFile");

        var metadataJson = form["request"];

        var metadata = JsonSerializer.Deserialize<BlobRequest>(metadataJson!);

        if (metadata is not null)
            return new BlobRequest() {FormFile= file, ContainerName = metadata.ContainerName, FileName = metadata.FileName };
        return null!;
    }
}
