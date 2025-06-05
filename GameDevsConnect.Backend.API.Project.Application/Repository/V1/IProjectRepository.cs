namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public interface IProjectRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetResponse> GetByIdAsync(string id);
    Task<ApiResponse> AddAsync(UpsertRequest addRequest);
    Task<ApiResponse> UpdateAsync(UpsertRequest updateRequest);
    Task<ApiResponse> DeleteAsync(string id);
}
