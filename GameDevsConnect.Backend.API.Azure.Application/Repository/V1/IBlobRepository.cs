using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Azure.Application.Repository.V1;

public interface IBlobRepository
{
    Task<GetResponse> GetBlobUrl(string fileName, string containerName);
    Task<ApiResponse> RemoveBlob(string fileName, string containerName);
    Task<ApiResponse> UploadBlob(IFormFile formFile, string containerName, string fileName);
    Task<ApiResponse> UpdateBlob(IFormFile formFile, string containerName, string fileName);
}