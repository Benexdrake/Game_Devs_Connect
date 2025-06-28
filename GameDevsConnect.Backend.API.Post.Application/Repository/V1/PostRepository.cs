namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public class PostRepository(GDCDbContext context) : IPostRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(AddPost addPost)
    {
        try
        {
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(addPost.Post!.Id));

            if (postDb is not null)
            {
                Log.Error(Message.EXIST(addPost.Post!.Id));
                return new ApiResponse(Message.EXIST(addPost.Post!.Id), false);
            }

            await _context.Posts.AddAsync(addPost.Post!);

            foreach (var tag in addPost.Tags!)
            {
                _context.PostTags.Add(new PostTagDTO(addPost.Post!.Id, tag.Id));
            }

            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(addPost.Post!.Id));
            return new ApiResponse(Message.ADD(addPost.Post.Id), true);
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
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Posts.Remove(postDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
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
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetByIdResponse(Message.NOTFOUND(id), false, null!);
            }

            return new GetByIdResponse(null!, true, postDb);
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
            var postDb = await _context.Posts.OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, postDb);
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
            var postDb = await _context.Posts.Where(x => x.OwnerId!.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, postDb);
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
            var postDb = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(post.Id));

            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(post.Id));
                return new ApiResponse(Message.NOTFOUND(post.Id), false);
            }

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(post.Id));
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
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetFullResponse(Message.NOTFOUND(id), false, null!, null!, null!, null!, null!);
            }

            // get Tag IDs from RequestTags
            var postTags = await _context.PostTags.Where(rt => rt.PostId!.Equals(id)).ToArrayAsync();


            // get Tags from TagIDS Array
            var tags = new List<TagDTO>();


            if(postDb.IsRequest)
            {
                foreach (var rt in postTags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == rt.TagId);
                    if (tag is null) continue;
                    tags.Add(tag);
                }
            }

            // Project
            var projectTitle = await _context.Projects.Where(x => x.Id.Equals(postDb.ProjectId)).Select(x => x.Title).FirstAsync();

            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(postDb.OwnerId));

            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(postDb.FileId));

            var tagsArray = tags.ToArray();

            return new GetFullResponse(null!, true, postDb, tagsArray, projectTitle!, owner, file); ;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, null!, null!, null!);
        }
    }

    public async Task<GetIdsResponse> GetCommentIdsAsync(string parentId)
    {
        try
        {
            var ids = await _context.Posts.Where(x => x.ParentId.Equals(parentId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync();
            return new GetIdsResponse(null!, true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }
}
