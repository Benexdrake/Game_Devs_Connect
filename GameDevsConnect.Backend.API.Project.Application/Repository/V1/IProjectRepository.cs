namespace GameDevsConnect.Backend.API.Project.Application.Repository.V1;

public interface IProjectRepository
{
    Task<GetIdsResponse> GetIdsAsync(CancellationToken token);
    Task<GetResponse> GetByIdAsync(string id, CancellationToken token);
    Task<ApiResponse> AddAsync(UpsertProject addPost, CancellationToken token);
    Task<ApiResponse> UpdateAsync(UpsertProject updatePost, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token);
}
