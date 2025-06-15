namespace GameDevsConnect.Backend.API.Comment.Application.Repository.V1;

public class CommentRepository(GDCDbContext context) : ICommentRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(CommentModel comment)
    {
        try
        {
            Message.Id = comment.Id;
            var commentDb = _context.Comments.FirstOrDefault(x => x.Id.Equals(comment.Id));

            if (commentDb != null)
            {
                Log.Error(Message.EXIST);
                return new ApiResponse(Message.EXIST, false);
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new ApiResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string commentId)
    {
        try
        {
            Message.Id = commentId;

            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(commentId));

            if (commentDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Comments.Remove(commentDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new ApiResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }

    }

    public async Task<GetById> GetByIdAsync(string commentId)
    {
        try
        {
            Message.Id = commentId;

            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(commentId));

            if (commentDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetById(Message.NOTFOUND, false, null!);
            }

            return new GetById(null!, true, commentDb);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetById(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsByRequestId> GetIdsByRequestIdAsync(string requestId)
    {
        try
        {
            var ids = await _context.Comments.Where(x => x.RequestId!.Equals(requestId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsByRequestId(null!, true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsByRequestId(ex.Message, false, null!);
        }
    }

    public async Task<GetCountByRequestId> GetCountByRequestIdAsync(string requestId)
    {
        try
        {
            var count = (await _context.Comments.Where(x => x.RequestId!.Equals(requestId)).Select(x => x.Id).ToListAsync()).Count;
            return new GetCountByRequestId(null!, true, count);

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetCountByRequestId(ex.Message, false, 0);
        }
    }

    public async Task<ApiResponse> UpdateAsync(CommentModel comment)
    {
        try
        {
            Message.Id = comment.Id;

            var commentDB = _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(comment.Id));

            if (commentDB is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new ApiResponse(Message.UPDATE, true);

        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
