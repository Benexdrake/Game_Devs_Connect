namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;
public interface IFileRepository
{
    Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID);
    Task<GetByIdResponse> GetByIdAsync(string fileId);
    Task<AddUpdateDeleteResponse> AddAsync(FileModel file);
    Task<AddUpdateDeleteResponse> UpdateAsync(FileModel file);
    Task<AddUpdateDeleteResponse> DeleteAsync(string fileId);
    Task<GetIdsbyId> GetByRequestIdAsync(string requestId);
}
