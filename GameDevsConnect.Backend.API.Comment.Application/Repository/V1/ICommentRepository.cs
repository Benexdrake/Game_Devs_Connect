namespace GameDevsConnect.Backend.API.Comment.Application.Repository.V1;

public interface ICommentRepository
{
    // Get Count from Comments by Parent ID
    Task<GetCountByRequestId> GetCountByRequestIdAsync(string requestId);

    // Get Comment Ids by Request ID
    Task<GetIdsByRequestId> GetIdsByRequestIdAsync(string requestId);

    // Get Comment by ID
    Task<GetById> GetByIdAsync(string commentId);

    // Add Comment
    Task<AddUpdateDeleteResponse> AddAsync(CommentModel comment);

    // Update Comment
    Task<AddUpdateDeleteResponse> UpdateAsync(CommentModel comment);

    // Delete Comment
    Task<AddUpdateDeleteResponse> DeleteAsync(string commentId);
}
