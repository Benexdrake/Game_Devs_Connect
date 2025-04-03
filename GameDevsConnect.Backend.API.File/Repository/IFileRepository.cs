namespace GameDevsConnect.Backend.API.File.Repository;
public interface IFileRepository
{
    Task<APIResponse> GetIdsByOwnerIdAsync(string ownerID);
    Task<APIResponse> GetByIdAsync(string fileId);
    Task<APIResponse> AddAsync(FileModel file);
    Task<APIResponse> UpdateAsync(FileModel file);
    Task<APIResponse> DeleteAsync(string fileId);
    Task<APIResponse> GetByRequestIdAsync(string id);
}
