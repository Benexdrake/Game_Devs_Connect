namespace GameDevsConnect.Backend.API.Tag.Application.Repository;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddAsync(TagModel tag)
    {
        try
        {
            tag.Id = 0;
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Tag!.Equals(tag.Tag));

            if (tagsDb is not null)
            {
                Log.Error($"Tag: {tag.Tag} exists already");
            }

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            if (tagsDb is null)
            {
                Log.Error($"Tag {id} does not exist");
                return false;
            }

            _context.Tags.Remove(tagsDb);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<TagModel[]> GetAsync()
    {
        try
        {
            var tags = await _context.Tags.ToArrayAsync();

            return tags;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return [];
        }
    }

    public async Task<bool> UpdateAsync(TagModel tag)
    {
        try
        {
            var tagsDb = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tag.Id);
            if (tagsDb is null)
            {
                Log.Error($"Tag {tag.Id} does not exist");
                return false;
            }

            tagsDb.Tag = tag.Tag;
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
}
