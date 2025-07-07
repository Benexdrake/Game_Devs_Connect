using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public interface IPostRepository
{
    Task<GetIdsResponse> GetIdsAsync(GetPostIdsRequest request ,CancellationToken token);
    Task<GetByIdResponse> GetByIdAsync(string id, CancellationToken token);
    Task<GetFullResponse> GetFullByIdAsync(string id, CancellationToken token);
    Task<GetIdsResponse> GetByUserIdAsync(string userId, CancellationToken token);
    Task<GetIdsResponse> GetCommentIdsAsync(string parentId, CancellationToken token);
    Task<ApiResponse> AddAsync(UpsertPost addPost, CancellationToken token);
    Task<ApiResponse> UpdateAsync(UpsertPost updatePost, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token);
}
