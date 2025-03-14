namespace Backend.Interfaces;
public interface IFileRepository
{
    Task<APIResponse> GetFileIdsByOwnerIdAsync(string ownerID);
    Task<APIResponse> GetFileByIdAsync(int fileId);
    Task<APIResponse> AddFileAsync(Models.File file);
    Task<APIResponse> UpdateFileAsync(Models.File file);
    Task<APIResponse> DeleteFileAsync(int fileId);
    Task<APIResponse> GetFilesByRequestId(int id);
}
