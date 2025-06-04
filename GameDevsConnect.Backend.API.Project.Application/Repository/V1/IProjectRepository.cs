namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public interface IProjectRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetResponse> GetByIdAsync(string id);
    Task<AddUpdateDeleteResponse> AddAsync(UpsertRequest addRequest);
    Task<AddUpdateDeleteResponse> UpdateAsync(UpsertRequest updateRequest);
    Task<AddUpdateDeleteResponse> DeleteAsync(string id);
}
