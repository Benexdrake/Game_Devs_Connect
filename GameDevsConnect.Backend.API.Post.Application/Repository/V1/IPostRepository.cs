namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public interface IPostRepository
{
    Task<GetIdsResponse> GetIdsAsync();
    Task<GetByIdResponse> GetByIdAsync(string id);
    Task<GetFullResponse> GetFullByIdAsync(string id);
    Task<GetIdsResponse> GetByUserIdAsync(string userId);
    Task<GetIdsResponse> GetCommentIdsAsync(string parentId);
    Task<ApiResponse> AddAsync(AddPost addPost);
    Task<ApiResponse> UpdateAsync(PostDTO post);
    Task<ApiResponse> DeleteAsync(string id);
}
