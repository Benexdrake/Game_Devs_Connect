namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public interface IProjectRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetResponse> GetByIdAsync(string id);
    Task<ApiResponse> AddAsync(UpsertProject addPost);
    Task<ApiResponse> UpdateAsync(UpsertProject updatePost);
    Task<ApiResponse> DeleteAsync(string id);
}
