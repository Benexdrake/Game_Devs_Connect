namespace GameDevsConnect.Backend.API.Comment.Repository;

public interface ICommentRepository
{
    // Get Count from Comments by Parent ID
    Task<APIResponse> GetCountByParentIdAsync(string requestId);

    // Get Comments by Parent ID
    Task<APIResponse> GetByParentsIdAsync(string requestId);

    // Get Comment by ID
    Task<APIResponse> GetByIdAsync(string commentId);

    // Add Comment
    Task<APIResponse> AddAsync(CommentModel comment);

    // Update Comment
    Task<APIResponse> UpdateAsync(CommentModel comment);

    // Delete Comment
    Task<APIResponse> DeleteAsync(string commentId);
}
