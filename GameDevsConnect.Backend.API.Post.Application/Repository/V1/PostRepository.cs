namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public class PostRepository(GDCDbContext context) : IPostRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(AddPost addRequest)
    {
        try
        {
            Message.Id = addRequest.Request!.Id;
            var requestDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(addRequest.Request!.Id));

            if (requestDb is not null)
            {
                Log.Error(Message.EXIST);
                return new ApiResponse(Message.EXIST, false);
            }

            await _context.Posts.AddAsync(addRequest.Request!);

            foreach (var tag in addRequest.Tags!)
            {
                _context.PostTags.Add(new PostTagDTO(addRequest.Request!.Id, tag.Id));
            }

            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new ApiResponse(Message.ADD, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id)
    {
        try
        {
            Message.Id = id;
            var request = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Posts.Remove(request);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new ApiResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string id)
    {
        try
        {
            var request = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetByIdResponse(Message.NOTFOUND, false, null!);
            }

            return new GetByIdResponse(null!, true, request);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetIdsAsync()
    {
        try
        {
            var requests = await _context.Posts.OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, requests);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetByUserIdAsync(string userId)
    {
        try
        {
            var requests = await _context.Posts.Where(x => x.OwnerId!.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, requests);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(PostDTO post)
    {
        try
        {
            var Dbrequest = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(post.Id));

            if (Dbrequest is null)
            {
                Log.Error(Message.NOTFOUND);
                return new ApiResponse(Message.NOTFOUND, false);
            }

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetFullResponse> GetFullByIdAsync(string id)
    {
        try
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (post is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetFullResponse(Message.NOTFOUND, false, null!, null!, null!, null!, null!);
            }

            // get Tag IDs from RequestTags
            var requestTags = await _context.PostTags.Where(rt => rt.PostId!.Equals(id)).ToArrayAsync();


            // get Tags from TagIDS Array
            var tags = new List<TagDTO>();


            if(post.IsRequest)
            {
                foreach (var rt in requestTags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == rt.TagId);
                    if (tag is null) continue;
                    tags.Add(tag);
                }
            }

            // Project
            var projectTitle = await _context.Projects.Where(x => x.Id.Equals(post.ProjectId)).Select(x => x.Title).FirstAsync();

            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(post.OwnerId));

            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(post.FileId));

            var tagsArray = tags.ToArray();

            return new GetFullResponse(null!, true, post, tagsArray, projectTitle!, owner, file); ;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, null!, null!, null!);
        }
    }
}
