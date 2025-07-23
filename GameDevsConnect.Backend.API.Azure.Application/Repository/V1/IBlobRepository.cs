namespace GameDevsConnect.Backend.API.Azure.Application.Repository.V1;

public interface IBlobRepository
{
    Task<GetResponse> GetBlobUrl(string fileName, string containerName);
    Task<ApiResponse> RemoveBlob(string fileName, string containerName);
    Task<ApiResponse> UploadBlob(HttpRequest request);
}