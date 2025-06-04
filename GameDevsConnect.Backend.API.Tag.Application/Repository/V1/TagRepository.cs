namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<AddUpdateDeleteTagResponse> AddAsync(TagModel tag)
    {
        try
        {
            tag.Id = 0;
            Message.Id = tag.Tag!;
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Tag!.Equals(tag.Tag));

            if (tagsDb is not null)
            {
                Log.Error(Message.EXIST);
                return new AddUpdateDeleteTagResponse(Message.EXIST,false);
            }

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new AddUpdateDeleteTagResponse(Message.ADD,true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteTagResponse(ex.Message, false);
        }
    }

    public async Task<AddUpdateDeleteTagResponse> DeleteAsync(int id)
    {
        try
        {
            Message.Id = id.ToString();
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteTagResponse(Message.NOTFOUND,false);
            }

            _context.Tags.Remove(tagsDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new AddUpdateDeleteTagResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteTagResponse(ex.Message, false);
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

    public async Task<AddUpdateDeleteTagResponse> UpdateAsync(TagModel tag)
    {
        try
        {
            Message.Id = tag.Tag!;
            var tagsDb = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tag.Id);
            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteTagResponse(Message.NOTFOUND, false);
            }

            tagsDb.Tag = tag.Tag;
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteTagResponse(Message.UPDATE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteTagResponse(ex.Message,false);
        }
    }
}
