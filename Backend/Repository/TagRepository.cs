
using Backend.Models;

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

                if (tagsDb is not null) return new APIResponse("Tag exists in DB", false);

                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                return new APIResponse("Tag saved", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false);
            }
        }

        public async Task<APIResponse> DeleteTag(int id)
        {
            try
            {
                var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tagsDb is null) return new APIResponse("Tag didnt exist", false);

                _context.Tags.Remove(tagsDb);
                await _context.SaveChangesAsync();

                return new APIResponse("Tag deleted", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false);
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
                return new APIResponse(ex.Message, false);
            }
        }

        public async Task<APIResponse> UpdateTag(Tag tag)
        {
            try
            {
                var tagsDb = await _context.Tags.FirstOrDefaultAsync(x => x.Name == tag.Name);
                if (tagsDb is null) return new APIResponse("Tag didnt exist", false);

                tagsDb.Name = tag.Name;
                await _context.SaveChangesAsync();

                return new APIResponse("Tag updated", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new APIResponse(ex.Message, false);
            }
        }
    }
}
