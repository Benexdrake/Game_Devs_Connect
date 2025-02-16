﻿
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class RequestRepository(GdcContext context) : IRequestRepository
{
    private readonly GdcContext _context = context;
    public async Task<APIResponse> AddRequest(RequestTags rt)
    {
        try
        {
            var DbRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(rt.Request.Id));

            if (DbRequest is not null) return new APIResponse("Request Exists in DB",false);

            var test = await _context.Requests.AddAsync(rt.Request);
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

                //var tagDb = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

                //if(tagDb is not null)
                //{
                //}
                _context. RequestTags.Add(requestTag);
            }
            await _context.SaveChangesAsync();
            

            return new APIResponse("Request saved in DB", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> DeleteRequest(int id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false);

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return new APIResponse("Request got deleted", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<APIResponse> GetRequestById(int id)
    {
        try
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (request is null) return new APIResponse("Request dont exist", false);

            var u = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            var p = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.ProjectId);

            var test = _context.RequestTags.ToList();
            var tags = _context.RequestTags.Where(x => x.RequestId == id).Select(rt => _context.Tags.FirstOrDefault(t => t.Id == rt.TagId)).ToList();

            if (u is not null)
            {
                var title = "";
                if (p is not null)
                    title = p.Name;
                var user = new {id=u.Id, username=u.Username, avatar=u.Avatar };
            }
                return new APIResponse("", true, new { request, user=u, title=p?.Name, tags });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }

    public async Task<IEnumerable<int>> GetRequests()
    {
        var requests = await _context.Requests.OrderByDescending(x => x.Created).ToListAsync();
        return requests.Select(x => x.Id).ToList();
    }

    public async Task<APIResponse> UpdateRequest(Request request)
    {
        try
        {
            var Dbrequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (Dbrequest is null) return new APIResponse("Request dont exist", false);

            // Update Request
            Dbrequest.Title = request.Title;
            Dbrequest.Description = request.Description;
            Dbrequest.Fileurl = request.Fileurl;

            await _context.SaveChangesAsync();

            return new APIResponse("Request got updated", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new APIResponse(ex.Message, false);
        }
    }
}
