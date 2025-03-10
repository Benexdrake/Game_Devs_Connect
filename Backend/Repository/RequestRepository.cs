namespace Backend.Repository;

public class RequestRepository(GdcContext context, INotificationRepository repository) : IRequestRepository
{
    private readonly GdcContext _context = context;
    private readonly INotificationRepository _repository = repository;

    public async Task<APIResponse> AddRequest(RequestTags rt)
    {
        try
        {
            var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(rt.Request.Id));

            if (DbRequest is not null) return new APIResponse("Request Exists in DB",false, new { });

            await _context.Requests.AddAsync(rt.Request);
            _context.SaveChanges();

            // Deleting all RequestTag and saving new
            var requestTags = _context.RequestTags.Where(x => x.RequestId.Equals(rt.Request.Id)).ToList();

            await _context.RequestTags.Where(x => x.RequestId.Equals(rt.Request.Id)).ExecuteDeleteAsync();

            

            foreach (var tag in rt.Tags)
            {
                var requestTag = new RequestTag
                {
                    RequestId = rt.Request.Id,
                    TagId = tag.Id
                };


                _context. RequestTags.Add(requestTag);
            }

            await _context.SaveChangesAsync();
            

            return new APIResponse("Request saved in DB", true, rt.Request.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteRequest(int id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got deleted", true, new { });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetFilesByRequestId(int id)
    {
        var fileIds = await _context.Comments.Where(x => x.ParentId == id).Where(x => x.FileId != 0).Select(x => x.FileId).ToListAsync();

        return new APIResponse("", true, fileIds);
    }

    public async Task<APIResponse> getFullRequestById(int id, string userId)
    {
        try
        {
            var likeId = userId + "-" + id;

            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

            var tags = await _context.RequestTags.Where(rt => rt.RequestId == id).Select(rt => _context.Tags.FirstOrDefault(t => t.Id == rt.TagId)).ToListAsync();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.OwnerId));

            var commentIds = (await _context.Comments.Where(x => x.ParentId == id).Select(x => x.Id).ToListAsync()).Count;

            var likes = (await _context.RequestLikes.Where(x => x.RequestId == id).ToListAsync()).Count;

            var liked = await _context.RequestLikes.AnyAsync(x => x.Id.Equals(likeId));

            return new APIResponse("", true, new {request, tags, user= new { id = user?.Id, username = user?.Username, avatar = user?.Avatar }, commentIds, likes, liked });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetRequestById(int id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false, new { });

           
            return new APIResponse("", true, request);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetRequests()
    {
        var requests = await _context.Requests.OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
        return new APIResponse("", true, requests);
    }

    public async Task<APIResponse> GetRequestsByUserId(string userId)
    {
        var requests = await _context.Requests.Where(x => x.OwnerId.Equals(userId)).OrderByDescending(x => x.Created).Select(x => x.Id).ToListAsync();
        return new APIResponse("", true, requests);
    }

    public async Task<APIResponse> LikesOnRequest(int requestId, string userId, bool liked)
    {
        var id = userId + "-" + requestId;

        var request_likes = await _context.RequestLikes.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (request_likes is null)
            _context.RequestLikes.Add(new() { Id = id, RequestId=requestId, UserId=userId });
        else if(request_likes is not null)
            _context.RequestLikes.Remove(request_likes);

        await _context.SaveChangesAsync();


        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(requestId));
        // Check if userId == ownerId

        if (request is not null && !request.OwnerId.Equals(userId))
        {
            var notification = new Notification() { Id = id, RequestId = requestId, UserId = userId, Seen = "", Type = 1, OwnerId = request.OwnerId };
            var response = await _repository.AddNotification(notification);
        }

        return new APIResponse("Likes changed", true, new { });
    }

    public async Task<APIResponse> UpdateRequest(Request request)
    {
        try
        {
            var Dbrequest = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null) return new APIResponse("Request dont exist", false, new { });

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got updated", true, new { });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
