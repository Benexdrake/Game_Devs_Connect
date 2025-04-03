namespace GameDevsConnect.Backend.API.Comment.Repository;

public class CommentRepository(CommentDBContext context) : ICommentRepository
{
    private readonly CommentDBContext _context = context;

    public async Task<APIResponse> AddAsync(CommentModel comment)
    {
        try
        {
            var commentDb = _context.Comments.FirstOrDefault(x => x.Id.Equals(comment.Id));

            if (commentDb != null) return new APIResponse("Comment already exist", false, new { });

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new APIResponse("Comment saved",true, comment.Id);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new {});
        }
    }

    public async Task<APIResponse> DeleteAsync(string commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(commentId));
            if (commentDb is null) return new APIResponse("Comment dont exists", false, new { });

            _context.Comments.Remove(commentDb);
            await _context.SaveChangesAsync();

            return new APIResponse("Comment deleted",true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message,false, new { });
        }

    }

    public async Task<APIResponse> GetByIdAsync(string commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(commentId));
            if (commentDb is null) return new APIResponse("Comment dont exists", false, new { });

            return new APIResponse("",true,commentDb);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message,false, new { });
        }
    }

    public async Task<APIResponse> GetByParentsIdAsync(string requestId)
    {
        try
        {
            var comments = await _context.Comments.Where(x => x.RequestId.Equals(requestId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
            return new APIResponse("",true, comments);

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetCountByParentIdAsync(string requestId)
    {
        try
        {
            var comments = (await _context.Comments.Where(x => x.RequestId.Equals(requestId)).Select(x => x.Id).ToListAsync()).Count;
            return new APIResponse("", true, comments);

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> UpdateAsync(CommentModel comment)
    {
        try
        {
            var commentDB = _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(comment.Id));
            if (commentDB is null) return new APIResponse("Comment dont exist", false, new { });

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return new APIResponse("Comment Updated", true, new { });

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
