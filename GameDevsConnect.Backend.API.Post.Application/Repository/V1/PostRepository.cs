using static GameDevsConnect.Backend.API.Configuration.ApiEndpointsV1;

namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public class PostRepository(GDCDbContext context) : IPostRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(UpsertPost addPost, CancellationToken token)
    {
        try
        {
            addPost.Post!.Id = Guid.NewGuid().ToString();

            var validator = new Validator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(addPost.Post!, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(addPost.Post!.Id));
                return new ApiResponse(Message.VALIDATIONERROR(addPost.Post!.Id), false, [.. errors]);
            }

            await _context.Posts.AddAsync(addPost.Post!, token);

            foreach (var tag in addPost.Tags!)
            {
                await _context.PostTags.AddAsync(new PostTagDTO(addPost.Post!.Id, tag.Id), token);
            }

            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(addPost.Post!.Id));
            return new ApiResponse(Message.ADD(addPost.Post.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token)
    {
        try
        {
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Posts.Remove(postDb);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string id, CancellationToken token)
    {
        try
        {
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

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

    public async Task<GetIdsResponse> GetIdsAsync(CancellationToken token)
    {
        try
        {
            var postDb = await _context.Posts.OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync(token);
            return new GetIdsResponse(null!, true, postDb);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetByUserIdAsync(string userId, CancellationToken token)
    {
        try
        {
            var postDb = await _context.Posts
                                         .Where(x => x.OwnerId!.Equals(userId))
                                         .OrderByDescending(x => x.Created)
                                         .Select(x => x.Id)
                                         .ToArrayAsync(token);

            return new GetIdsResponse(null!, true, postDb);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(UpsertPost updatePost, CancellationToken token)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Update);

            var valid = await validator.ValidateAsync(updatePost.Post!, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(updatePost.Post!.Id));
                return new ApiResponse(Message.VALIDATIONERROR(updatePost.Post!.Id), false, [.. errors]);
            }

            _context.Posts.Update(updatePost.Post!);
            await _context.SaveChangesAsync(token);

            // Find all PostTags and delete and add new

            Log.Information(Message.UPDATE(updatePost.Post!.Id));
            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetFullResponse> GetFullByIdAsync(string id, CancellationToken token)
    {
        try
        {
            var postDb = await _context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id), token);
            if (postDb is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetFullResponse(Message.NOTFOUND(id), false, null!, null!, null!, null!, null!);
            }

            // get Tag IDs from RequestTags
            var postTags = await _context.PostTags.Where(rt => rt.PostId!.Equals(id)).ToArrayAsync(token);


            // get Tags from TagIDS Array
            var tags = new List<TagDTO>();


            if(postDb.IsRequest)
            {
                foreach (var rt in postTags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == rt.TagId, token);
                    if (tag is null) continue;
                    tags.Add(tag);
                }
            }

            // Project
            var projectTitle = await _context.Projects.Where(x => x.Id.Equals(postDb.ProjectId)).Select(x => x.Title).FirstAsync(token);

            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(postDb.OwnerId), token);

            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(postDb.FileId), token);

            var tagsArray = tags.ToArray();

            return new GetFullResponse(null!, true, postDb, tagsArray, projectTitle!, owner, file);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, null!, null!, null!);
        }
    }

    public async Task<GetIdsResponse> GetCommentIdsAsync(string parentId, CancellationToken token)
    {
        try
        {
            var ids = await _context.Posts.Where(x => x.ParentId.Equals(parentId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToArrayAsync(token);
            return new GetIdsResponse(null!, true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }
}
