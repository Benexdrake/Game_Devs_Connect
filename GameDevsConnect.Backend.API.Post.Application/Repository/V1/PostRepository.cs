namespace GameDevsConnect.Backend.API.Post.Application.Repository.V1;

public class PostRepository(GDCDbContext context) : IPostRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<AddResponse> AddAsync(UpsertPost addPost, CancellationToken token)
    {
        try
        {
            addPost.Post!.Id = Guid.NewGuid().ToString();

            addPost.Post!.Created = DateTime.UtcNow;

            var validator = new PostValidator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(addPost.Post!, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(addPost.Post!.Id));
                return new AddResponse(Message.VALIDATIONERROR(addPost.Post!.Id), false, "", [.. errors]);
            }

            await _context.Posts.AddAsync(addPost.Post!, token);

            foreach (var tag in addPost.Tags!)
            {
                await _context.PostTags.AddAsync(new PostTagDTO(addPost.Post!.Id, tag.Tag), token);
            }

            // Add Post_file über Schleife
            foreach (var fileId in addPost.FileIds)
            {
                await _context.PostFiles.AddAsync(new PostFileDTO { FileId = fileId, PostId = addPost.Post.Id });
            }

            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(addPost.Post!.Id));
            return new AddResponse(Message.ADD(addPost.Post.Id), true, addPost.Post.Id, null!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddResponse(ex.Message, false, "", null!);
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

    public async Task<GetIdsResponse> GetIdsAsync(GetPostIdsRequest request, CancellationToken token)
    {
        try
        {
            IQueryable<PostDTO> postQuery = _context.Posts;

            var ids = await postQuery.Where(p =>
            p.Message!.Contains(request.SearchTerm) && p.ParentId.Equals(request.ParentId))
            .OrderByDescending(x => x.Created)
            .Skip(((request.Page - 1) * request.PageSize))
            .Take(request.PageSize)
            .Select(p => p.Id)
            .ToListAsync(token);

            return new GetIdsResponse(null!, true, [.. ids]);
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
                                         .Where(x => x.OwnerId!.Equals(userId) && x.ParentId.Equals(string.Empty))
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
            var validator = new PostValidator(_context, ValidationMode.Update);

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
                return new GetFullResponse(Message.NOTFOUND(id), false, null!, null!, 0, null!, null!, null!, 0, 0);
            }

            var postTags = await _context.PostTags.Where(rt => rt.PostId!.Equals(id)).ToArrayAsync(token);

            var tags = new List<TagDTO>();
            var questsCount = 0;

            if (postDb.HasQuest)
            {
                questsCount = await _context.Quests.Where(x => x.PostId!.Equals(id)).CountAsync(token);
            }

            foreach (var rt in postTags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Tag.Equals(rt.Tag), token);
                if (tag is null) continue;
                tags.Add(tag);
            }

            string? projectTitle = (await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(postDb.ProjectId), token))?.Title;

            var owner = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(postDb.OwnerId), token);

            var fileIds = await _context.PostFiles.Where(x => x.PostId.Equals(id)).Select(x => x.FileId).ToArrayAsync(token);

            var files = new List<FileDTO>();

            foreach (var fileId in fileIds)
            {
                var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId), token);
                if(file is null) continue;

                files.Add(file);
            }

            var commentsCount = await _context.Posts.Where(x => x.ParentId.Equals(id)).CountAsync(token);

            var likes = 0;

            var tagsArray = tags.ToArray();

            return new GetFullResponse(null!, true, postDb, [..files], questsCount, tagsArray, projectTitle!, owner, commentsCount, likes);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetFullResponse(ex.Message, false, null!, null!, 0, null!, null!, null!, 0, 0);
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
