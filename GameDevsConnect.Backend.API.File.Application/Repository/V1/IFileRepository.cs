namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;
public interface IFileRepository
{
    Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID);
    Task<GetByIdResponse> GetByIdAsync(string fileId);
    Task<ApiResponse> AddAsync(FileDTO file);
    Task<ApiResponse> UpdateAsync(FileDTO file);
    Task<ApiResponse> DeleteAsync(string fileId);
    Task<GetIdsbyId> GetByPostParentIdAsync(string parentId);
}
