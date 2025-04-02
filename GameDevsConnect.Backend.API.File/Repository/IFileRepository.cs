namespace GameDevsConnect.Backend.API.File.Repository;
public interface IFileRepository
{
    Task<APIResponse> GetIdsByOwnerIdAsync(string ownerID);
    Task<APIResponse> GetByIdAsync(int fileId);
    Task<APIResponse> AddAsync(FileModel file);
    Task<APIResponse> UpdateAsync(FileModel file);
    Task<APIResponse> DeleteAsync(int fileId);
    Task<APIResponse> GetByRequestIdAsync(int id);
}
