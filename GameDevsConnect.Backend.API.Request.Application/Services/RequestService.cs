using GameDevsConnect.Backend.API.Request.Application.Repository;

namespace GameDevsConnect.Backend.API.Request.Application.Services;

public class RequestService(IRequestRepository repo) : IRequestService
{
    private readonly IRequestRepository repo = repo;

    public async Task<APIResponse> AddAsync(AddRequest addRequest)
    {
        var response = await repo.AddAsync(addRequest);
        return new APIResponse(response, response!);
    }

    public async Task<APIResponse> DeleteAsync(string id)
    {
        var response = await repo.DeleteAsync(id);
        return new APIResponse(response, response!);
    }

    public async Task<APIResponse> GetByIdAsync(string id)
    {
        var response = await repo.GetByIdAsync(id);
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> GetByUserIdAsync(string userId)
    {
        var response = await repo.GetByUserIdAsync(userId);
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> GetFullByIdAsync(string id)
    {
        var response = await repo.GetFullByIdAsync(id);
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> GetIdsAsync()
    {
        var response = await repo.GetIdsAsync();
        return new APIResponse(response is not null, response!);
    }

    public async Task<APIResponse> UpdateAsync(RequestModel request)
    {
        var response = await repo.UpdateAsync(request);
        return new APIResponse(response, response!);
    }
}
