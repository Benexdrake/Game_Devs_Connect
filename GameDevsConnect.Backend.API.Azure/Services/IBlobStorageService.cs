namespace GameDevsConnect.Backend.API.Azure.Services;
public interface IBlobStorageService
{
    Task<string> GetBlobUrl(string fileName, string containerName);
    Task<bool> RemoveBlob(string fileName, string containerName);
    Task<string?> UploadBlob(IFormFile formFile, string containerName, string fileName);
}