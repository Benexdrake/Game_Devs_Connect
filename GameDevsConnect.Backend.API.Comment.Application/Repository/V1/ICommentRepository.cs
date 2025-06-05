namespace GameDevsConnect.Backend.API.Comment.Application.Repository.V1;

public interface ICommentRepository
{
    Task<GetCountByRequestId> GetCountByRequestIdAsync(string requestId);

    Task<GetIdsByRequestId> GetIdsByRequestIdAsync(string requestId);

    Task<GetById> GetByIdAsync(string commentId);

    Task<ApiResponse> AddAsync(CommentModel comment);

    Task<ApiResponse> UpdateAsync(CommentModel comment);

    Task<ApiResponse> DeleteAsync(string commentId);
}
