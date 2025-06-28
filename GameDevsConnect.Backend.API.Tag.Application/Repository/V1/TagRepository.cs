namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;
public class TagRepository(GDCDbContext context) : ITagRepository
{
    private readonly GDCDbContext _context = context;
    public async Task<ApiResponse> AddAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(tag, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(tag.Tag!));
                return new ApiResponse(Message.VALIDATIONERROR(tag.Tag!), false, [.. errors]);
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

    public async Task<ApiResponse> DeleteAsync(int id, CancellationToken token)
    {
        try
        {
            var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id, token);

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

    public async Task<GetTagsResponse> GetAsync(CancellationToken token)
    {
        try
        {
            var tags = await _context.Tags.ToArrayAsync(token);

            return new GetTagsResponse(null!, true, tags);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetTagsResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Update);

            var valid = await validator.ValidateAsync(tag, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(tag.Tag!));
                return new ApiResponse(Message.VALIDATIONERROR(tag.Tag!), false, [.. errors]);
            }

            _context.Tags.Update(tag);
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
