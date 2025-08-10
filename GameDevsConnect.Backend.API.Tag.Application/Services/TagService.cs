using GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

namespace GameDevsConnect.Backend.API.Tag.Application.Services;

public class TagService(ITagRepository repo, GDCDbContext context) : ITagService
{
    private readonly ITagRepository _repo = repo;
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(TagDTO tag, CancellationToken token)
    {
        try
        {
            var status = await _repo.AddAsync(tag, token);

            return new ApiResponse("", status);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string tag, CancellationToken token)
    {
        try
        {
            var status = await _repo.DeleteAsync(tag, token);
            return new ApiResponse(Message.DELETE(tag), status);
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
            var tags = await _repo.GetAsync(token);

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
            var status = await _repo.UpdateAsync(tag, token);

            return new ApiResponse("", status);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
