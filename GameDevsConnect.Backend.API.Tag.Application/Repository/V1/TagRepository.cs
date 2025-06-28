namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(TagDTO tag)
    {
        try
        {
            tag.Id = 0;
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Tag!.Equals(tag.Tag));

            if (tagsDb is not null)
            {
                Log.Error(Message.EXIST(tag.Tag!));
                return new ApiResponse(Message.EXIST(tag.Tag!), false);
            }

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(tag.Tag!));
            return new ApiResponse(Message.ADD(tag.Tag!), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(int id)
    {
        try
        {
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND(id.ToString()));
                return new ApiResponse(Message.NOTFOUND(id.ToString()), false);
            }

            _context.Tags.Remove(tagsDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(id.ToString()));
            return new ApiResponse(Message.DELETE(id.ToString()), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetTagsResponse> GetAsync()
    {
        try
        {
            var tags = await _context.Tags.ToArrayAsync();

            return new GetTagsResponse(null!, true, tags);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetTagsResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(TagDTO tag)
    {
        try
        {
            var tagsDb = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tag.Id);
            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND(tag.Tag!));
                return new ApiResponse(Message.NOTFOUND(tag.Tag!), false);
            }

            tagsDb.Tag = tag.Tag;
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(tag.Tag!));
            return new ApiResponse(Message.UPDATE(tag.Tag!), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
