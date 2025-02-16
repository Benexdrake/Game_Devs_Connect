namespace Backend.Interfaces;

public interface ICommentRepository
{
    // Get Count from Comments by Parent ID
    Task<APIResponse> GetCommentsCountByParentIdAsync(int parentId);

    // Get Comments by Parent ID
    Task<APIResponse> GetCommentsByParentsIdAsync(int parentId);

    // Get Comment by ID
    Task<APIResponse> GetCommentByIdAsync(int commentId);

    // Add Comment
    Task<APIResponse> AddComment(Comment comment);

    // Update Comment
    Task<APIResponse> UpdateCommentAsync(Comment comment);

    // Delete Comment
    Task<APIResponse> DeleteCommentByIdAsync(int commentId);
}
