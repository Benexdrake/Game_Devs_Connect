using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Azure.Repository
{
    public interface IBlobRepository
    {
        Task<APIResponse> GetBlobUrl(string fileName, string containerName);
        Task<APIResponse> RemoveBlob(string fileName, string containerName);
        Task<APIResponse> UploadBlob(IFormFile formFile, string containerName, string fileName);
    }
}