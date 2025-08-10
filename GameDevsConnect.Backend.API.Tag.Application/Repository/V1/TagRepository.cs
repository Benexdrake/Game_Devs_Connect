namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<bool> AddAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var valid = await new Validation().ValidateTag(_context, ValidationMode.Add, tag, token);
            if (!valid)
                return false;
            
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

    public async Task<bool> DeleteAsync(string tag, CancellationToken token)
    {
        try
        {
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Tag.Equals(tag), token);

            if (tagsDb is null)
            {
                Log.Error(Message.NOTFOUND(tag));
                return false;
            }

            _context.Tags.Remove(tagsDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(tag));
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }

    public async Task<TagDTO[]> GetAsync(CancellationToken token)
    {
        try
        {
            var tags = await _context.Tags.ToArrayAsync(token);
            
            return tags;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return [];
        }
    }

    public async Task<bool> UpdateAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var valid = await new Validation().ValidateTag(_context, ValidationMode.Update, tag, token);
            if (!valid)
                return false;

            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(tag.Tag!));
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return false;
        }
    }
}
