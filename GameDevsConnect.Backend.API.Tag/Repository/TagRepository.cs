namespace GameDevsConnect.Backend.API.Tag.Repository
{
    public class TagRepository(TagDBContext context) : ITagRepository
    {
        private readonly TagDBContext _context = context;
        public async Task<APIResponse> AddAsync(TagModel tag)
        {
            try
            {
                var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Name == tag.Name);

                if (tagsDb is not null) return new APIResponse("Tag exists in DB", false, new { });

                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                return new APIResponse("Tag saved", true, new { });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> DeleteAsync(int id)
        {
            try
            {
                var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tagsDb is null) return new APIResponse("Tag didnt exist", false, new { });

                _context.Tags.Remove(tagsDb);
                await _context.SaveChangesAsync();

                return new APIResponse("Tag deleted", true, new { });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> GetAsync(int id)
        {
             try
            {
                var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tagsDb is null) return new APIResponse("Tag didnt exist", false, new { });

                return new APIResponse("", true, tagsDb);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> GetIdsAsync()
        {
            try
            {
                var tags = await _context.Tags.ToListAsync();

                return new APIResponse("", true, tags);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> UpdateAsync(TagModel tag)
        {
            try
            {
                var tagsDb = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tag.Id);
                if (tagsDb is null) return new APIResponse("Tag didnt exist", false, new { });

                tagsDb.Name = tag.Name;
                await _context.SaveChangesAsync();

                return new APIResponse("Tag updated", true, new { });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }
    }
}
