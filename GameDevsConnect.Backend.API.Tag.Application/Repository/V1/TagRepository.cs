namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var errors = await new Validation().ValidateTag(_context, ValidationMode.Add, tag, token);
            if (errors.Length > 0)
                return new ApiResponse(Message.VALIDATIONERROR(tag.Tag), false, errors);
            
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return new ApiResponse(Message.ADD(tag.Tag), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string tag, CancellationToken token)
    {
        try
        {
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Tag.Equals(tag), token);

            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND(tag));
                return new ApiResponse(Message.NOTFOUND(tag), false);
            }

            _context.Tags.Remove(tagsDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(tag));
            return new ApiResponse(Message.DELETE(tag), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }

    public async Task<GetTagsResponse> GetAsync(CancellationToken token)
    {
        try
        {
            var tags = await _context.Tags.ToArrayAsync(token);
            
            return new GetTagsResponse("", true, tags);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetTagsResponse("", false, []);
        }
    }

    public async Task<ApiResponse> UpdateAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var errors = await new Validation().ValidateTag(_context, ValidationMode.Update, tag, token);
            if (errors.Length > 0)
                return new ApiResponse(Message.VALIDATIONERROR(tag.Tag), false, errors);

            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(tag.Tag!));
            return new ApiResponse(Message.UPDATE(tag.Tag), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse("", false, [ex.Message]);
        }
    }
}
