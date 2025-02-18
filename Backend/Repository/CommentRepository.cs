
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
            return new APIResponse("Comment saved",true, comment.Id);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> DeleteCommentByIdAsync(int commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (commentDb is null) return new APIResponse("Comment dont exists", false);

            _context.Comments.Remove(commentDb);

            return new APIResponse("Comment deleted",true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message,false);
        }

    }

    public async Task<APIResponse> GetCommentByIdAsync(int commentId)
    {
        try
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (commentDb is null) return new APIResponse("Comment dont exists", false);

            return new APIResponse("",true,commentDb);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message,false);
        }
    }

    public async Task<APIResponse> GetCommentsByParentsIdAsync(int parentId)
    {
        try
        {
            var comments = await _context.Comments.Where(x => x.ParentId == parentId).Select(x => x.Id).ToListAsync();
            return new APIResponse("",true, comments);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
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
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> UpdateCommentAsync(Comment comment)
    {
        try
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return new APIResponse("Comment Updated", true);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }
}
