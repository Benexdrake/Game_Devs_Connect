namespace GameDevsConnect.Backend.API.Azure.Services;
public interface IBlobStorageService
{
    Task<(string, bool)> GetBlobUrl(string fileName, string containerName);
    Task<(string, bool)> RemoveBlob(string fileName, string containerName);
    Task<(string, bool)> UploadBlob(IFormFile formFile, string containerName, string fileName);
    Task<(string, bool)> UpdateBlob(IFormFile formFile, string containerName, string fileName);
}