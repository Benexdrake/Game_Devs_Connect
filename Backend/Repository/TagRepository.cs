namespace Backend.Repository
{
    public class TagRepository(GdcContext context) : ITagRepository
    {
        private readonly GdcContext _context = context;
        public async Task<APIResponse> AddTag(Tag tag)
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
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> DeleteTag(int id)
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
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> GetTags()
        {
            try
            {
                var tags = await _context.Tags.ToListAsync();

                return new APIResponse("", true, tags);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> GetTagsByRequestId(int requestId)
        {
            var tags = await _context.RequestTags.Where(x => x.RequestId == requestId).Select(rt => _context.Tags.FirstOrDefault(t => t.Id == rt.TagId)).ToListAsync();
            return new APIResponse("", true, tags);
        }

        public async Task<APIResponse> UpdateTag(Tag tag)
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
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }
    }
}
