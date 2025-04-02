namespace GameDevsConnect.Backend.API.Comment.Repository;

public interface ICommentRepository
{
    // Get Count from Comments by Parent ID
    Task<APIResponse> GetCountByParentIdAsync(int parentId);

    // Get Comments by Parent ID
    Task<APIResponse> GetByParentsIdAsync(int parentId);

    // Get Comment by ID
    Task<APIResponse> GetByIdAsync(int commentId);

    // Add Comment
    Task<APIResponse> AddAsync(CommentModel comment);

    // Update Comment
    Task<APIResponse> UpdateAsync(CommentModel comment);

    // Delete Comment
    Task<APIResponse> DeleteAsync(int commentId);
}
