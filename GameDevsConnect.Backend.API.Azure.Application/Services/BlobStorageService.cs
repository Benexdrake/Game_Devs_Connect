namespace GameDevsConnect.Backend.API.Azure.Services;
public class BlobStorageService(IConfiguration configuration) : IBlobStorageService
{
    private readonly IConfiguration _configuration = configuration;

    private async Task<BlobContainerClient?> GetBlobContainerClient(string containerName)
    {
        try
        {
            var container = new BlobContainerClient(_configuration["StorageConnectionString"], containerName);
            await container.CreateIfNotExistsAsync();

            return container;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null;
        }
    }

    public async Task<(string, bool)> UploadBlob(IFormFile formFile, string containerName, string fileName)
    {
        try
        {
            var blobName = $"{fileName}{Path.GetExtension(formFile.FileName)}";
            var container = await GetBlobContainerClient(containerName);

            if (container is null)
                return ("Container is null", false);

            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            memoryStream.Position = 0;
            var blob = container.GetBlobClient(blobName);

            var contentType = !string.IsNullOrWhiteSpace(formFile.ContentType)
                ? formFile.ContentType
                : GetContentTypeFromExtension(Path.GetExtension(formFile.FileName));

            var headers = new BlobHttpHeaders
            {
                ContentType = contentType
            };

            await blob.UploadAsync(memoryStream, new BlobUploadOptions
            {
                HttpHeaders = headers
            });
            return (blobName, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return (ex.Message, false);
        }
    }

    public async Task<(string, bool)> GetBlobUrl(string fileName, string containerName)
    {
        try
        {
            var container = await GetBlobContainerClient(containerName);

            if (container is null) return (string.Empty, false);

            var blob = container.GetBlobClient(fileName);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                ExpiresOn = DateTime.UtcNow.AddMinutes(5),
                Resource = "b"
            };
            blobSasBuilder.SetPermissions(BlobAccountSasPermissions.Read);
            return (blob.GenerateSasUri(blobSasBuilder).ToString(), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return (ex.Message, false);
        }
    }

    public async Task<(string, bool)> RemoveBlob(string fileName, string containerName)
    {
        try
        {
            var container = await GetBlobContainerClient(containerName);

            if (container is null) return ("", false);

            var blob = container.GetBlobClient(fileName);

            if (blob is null) return ("", false);

            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            return ("", true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return (ex.Message, false);
        }
    }

    public Task<(string, bool)> UpdateBlob(IFormFile formFile, string containerName, string fileName)
    {
        throw new NotImplementedException();
    }


    private string GetContentTypeFromExtension(string ext) => ext.ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".jpg" or ".jpeg" => "image/jpeg",
        ".gif" => "image/gif",
        ".svg" => "image/svg+xml",
        ".webp" => "image/webp",
        _ => "application/octet-stream"
    };

}
