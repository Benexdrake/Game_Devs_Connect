namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;
public interface IFileRepository
{
    Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID, CancellationToken token);
    Task<GetByIdResponse> GetByIdAsync(string fileId, CancellationToken token);
    Task<AddResponse> AddAsync(FileDTO file, CancellationToken token);
    Task<ApiResponse> UpdateAsync(FileDTO file, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string fileId, CancellationToken token);
    Task<GetIdsbyId> GetByPostParentIdAsync(string parentId, CancellationToken token);
}
