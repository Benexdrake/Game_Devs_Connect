using Grpc.Core;

namespace GameDevsConnect.Backend.API.Quest.Services;

public class APIService(IQuestRepository repo) : QuestProtoService.QuestProtoServiceBase
{
    private readonly IQuestRepository _repo = repo;

    public override async Task<Response> AddQuest(AddQuestRequest request, ServerCallContext context)
    {
        var response = new Response();
        var quest = new QuestDTO()
        {
            Id = request.Quest.Id,
            Description = request.Quest.Description,
            Difficulty = request.Quest.Difficulty,
            OwnerId = request.Quest.OwnerId,
            PostId = request.Quest.PostId,
            Title = request.Quest.Title
        };

        var addResponse = await _repo.AddAsync(quest, context.CancellationToken);

        response.Status = addResponse.Status;
        response.Message = addResponse.Message;
        response.Errors.AddRange(addResponse.Errors);

        return response;
    }

    public override async Task<Response> CompleteQuest(CompleteQuestRequest request, ServerCallContext context)
    {
        var response = new Response();

        var completeRequest = new Contract.Requests.CompleteQuestRequest();
        completeRequest.QuestId = request.QuestId;
        completeRequest.Message = request.Message;
        completeRequest.OwnerId = request.OwnerId;
        completeRequest.FileId = request.FileId;

        var completeResponse = await _repo.CompleteAsync(completeRequest, context.CancellationToken);

        return response;
    }

    public override async Task<Response> DeleteQuest(DeleteQuestRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteResponse = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Status = deleteResponse.Status;
        response.Message = deleteResponse.Message;
        response.Errors.AddRange(deleteResponse.Errors);

        return response;
    }

    public override async Task<GetIdsResponse> GetByPostId(GetByPostIdRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var response = await _repo.GetByPostIdAsync(request.Id, context.CancellationToken);

        getIdsResponse.Response.Status = response.Response.Status;
        getIdsResponse.Response.Message = response.Response.Message;
        getIdsResponse.Response.Errors.AddRange(response.Response.Errors);
        getIdsResponse.Ids.AddRange(response.Ids);

        return getIdsResponse;
    }

    public override async Task<GetIdsResponse> GetIds(GetIdsRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var response = await _repo.GetIdsAsync(request.Page, request.PageSize, request.SearchTerm, request.UserId, context.CancellationToken);

        getIdsResponse.Response.Status = response.Response.Status;
        getIdsResponse.Response.Message = response.Response.Message;
        getIdsResponse.Response.Errors.AddRange(response.Response.Errors);
        getIdsResponse.Ids.AddRange(response.Ids);

        return getIdsResponse;
    }

    public override async Task<GetQuestResponse> GetQuest(GetQuestRequest request, ServerCallContext context)
    {
        var getQuestResponse = new GetQuestResponse();

        var questResponse = await _repo.GetAsync(request.Id, request.UserId, context.CancellationToken);

        getQuestResponse.Quest = new Quest()
        {
            Id = questResponse.Quest.Id,
            Description = questResponse.Quest.Description,
            Difficulty = questResponse.Quest.Difficulty,
            OwnerId = questResponse.Quest.OwnerId,
            PostId = questResponse.Quest.PostId,
            Title = questResponse.Quest.Title
        };

        getQuestResponse.Response.Message = questResponse.Response.Message;
        getQuestResponse.Response.Status = questResponse.Response.Status;
        getQuestResponse.Response.Errors.AddRange(questResponse.Response.Errors);

        return getQuestResponse;
    }

    public override async Task<Response> UpdateQuest(UpdateQuestRequest request, ServerCallContext context)
    {
        var response = new Response();
        var quest = new QuestDTO()
        {
            Id = request.Quest.Id,
            Description = request.Quest.Description,
            Difficulty = request.Quest.Difficulty,
            OwnerId = request.Quest.OwnerId,
            PostId = request.Quest.PostId,
            Title = request.Quest.Title
        };

        var updateResponse = await _repo.UpdateAsync(quest, context.CancellationToken);

        response.Status = updateResponse.Status;
        response.Message = updateResponse.Message;
        response.Errors.AddRange(updateResponse.Errors);

        return response;
    }
}