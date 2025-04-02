namespace GameDevsConnect.Backend.API.Azure.Repository;
public class BlobRepository(IBlobStorageService service) : IBlobRepository
{
    private readonly IBlobStorageService _service = service;

    public async Task<APIResponse> GetBlobUrl(string fileName, string containerName)
    {
        try
        {
            var blobUrl = await _service.GetBlobUrl(fileName, containerName);

            return new APIResponse("", true, blobUrl);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> UploadBlob(IFormFile formFile, string containerName, string fileName)
    {
        try
        {
            var result = await _service.UploadBlob(formFile, containerName, fileName);
            if (string.IsNullOrEmpty(result)) return new APIResponse("Something went wrong", true, new { });
            if (result.Contains("ERROR")) return new APIResponse(result, true, new { });

            return new APIResponse("File uploaded", true, result);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> RemoveBlob(string fileName, string containerName)
    {
        try
        {
            var result = await _service.RemoveBlob(fileName, containerName);

            if (result is false) return new APIResponse("Something went wrong", true, new { });

            return new APIResponse("File deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
