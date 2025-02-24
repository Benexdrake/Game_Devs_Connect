namespace Backend.Repository;

public class CommentRepository(GdcContext context) : ICommentRepository
{
    private readonly GdcContext _context = context;

    public async Task<APIResponse> AddCommentAsync(Comment comment)
    {
        try
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var id = comment.OwnerId + "-" + comment.ParentId + "-" + comment.Id;
            var notification = new Notification() { Id = id, OwnerId = "", RequestId = comment.ParentId, Seen = "", Type = 2, UserId = comment.OwnerId };

            await new NotificationRepository(_context).AddNotification(notification);

            return new APIResponse("Comment saved",true, comment.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new {});
        }
    }

    public async Task<APIResponse> DeleteCommentByIdAsync(int commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (commentDb is null) return new APIResponse("Comment dont exists", false, new { });

            _context.Comments.Remove(commentDb);

            return new APIResponse("Comment deleted",true, new { });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message,false, new { });
        }

    }

    public async Task<APIResponse> GetCommentByIdAsync(int commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (commentDb is null) return new APIResponse("Comment dont exists", false, new { });

            return new APIResponse("",true,commentDb);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message,false, new { });
        }
    }

    public async Task<APIResponse> GetCommentsByParentsIdAsync(int parentId)
    {
        try
        {
            var comments = await _context.Comments.Where(x => x.ParentId == parentId).OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
            return new APIResponse("",true, comments);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetCommentsCountByParentIdAsync(int parentId)
    {
        try
        {
            var comments = (await _context.Comments.Where(x => x.ParentId == parentId).Select(x => x.Id).ToListAsync()).Count;
            return new APIResponse("", true, comments);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> UpdateCommentAsync(Comment comment)
    {
        try
        {
            var commentDB = _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == comment.Id);
            if (commentDB is null) return new APIResponse("Comment dont exist", false, new { });

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return new APIResponse("Comment Updated", true, new { });

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
