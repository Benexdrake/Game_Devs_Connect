namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;
public interface IFileRepository
{
    Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID);
    Task<GetByIdResponse> GetByIdAsync(string fileId);
    Task<ApiResponse> AddAsync(FileModel file);
    Task<ApiResponse> UpdateAsync(FileModel file);
    Task<ApiResponse> DeleteAsync(string fileId);
    Task<GetIdsbyId> GetByRequestIdAsync(string requestId);
}
