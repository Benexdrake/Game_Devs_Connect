using GameDevsConnect.Backend.API.Azure.Contract.Responses;
using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Azure.Repository
{
    public interface IBlobRepository
    {
        Task<GetResponse> GetBlobUrl(string fileName, string containerName);
        Task<AddUpdateDeleteResponse> RemoveBlob(string fileName, string containerName);
        Task<AddUpdateDeleteResponse> UploadBlob(IFormFile formFile, string containerName, string fileName);
        Task<AddUpdateDeleteResponse> UpdateBlob(IFormFile formFile, string containerName, string fileName);
    }
}