namespace GameDevsConnect.Backend.API.File.Services;

public class APIService(IFileRepository repo) : FileProtoService.FileProtoServiceBase
{
    private readonly IFileRepository _repo = repo;

    public override async Task<AddResponse> Add(UpsertFileRequest request, ServerCallContext context)
    {
        var addResponse = new AddResponse();

        var file = new FileDTO()
        {
            Id = request.File.Id,
            Url = request.File.Url,
            Type = request.File.Type,
            Extension = request.File.Extension,
            Size = request.File.Size,
            Created = DateTime.Now,
            OwnerId = request.File.OwnerId
        };

        var response = await _repo.AddAsync(file, context.CancellationToken);

        addResponse.Id = response.Id;
        addResponse.Response.Message = response.Response.Message;
        addResponse.Response.Status = response.Response.Status;
        addResponse.Response.Errors.AddRange(response.Response.Errors);

        return addResponse;
    }

    public override async Task<Response> Delete(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteResponse = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Message = deleteResponse.Message;
        response.Status = deleteResponse.Status;
        response.Errors.AddRange(deleteResponse.Errors);

        return response;
    }

    public override async Task<GetByIdResponse> GetById(IdRequest request, ServerCallContext context)
    {
        var getByIdResponse = new GetByIdResponse();

        var response = await _repo.GetByIdAsync(request.Id, context.CancellationToken);

        getByIdResponse.File = new File()
        {
            Id = response.File.Id,
            Url = response.File.Url,
            Type = response.File.Type,
            Extension = response.File.Extension,
            Size = response.File.Size,
            Created = response.File.Created.ToString(),
            OwnerId = response.File.OwnerId
        };
        getByIdResponse.Response.Message = response.Response.Message;
        getByIdResponse.Response.Status = response.Response.Status;
        getByIdResponse.Response.Errors.AddRange(response.Response.Errors);

        return getByIdResponse;
    }

    public override async Task<GetIdsResponse> GetIdsByOwnerId(IdRequest request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var response = await _repo.GetIdsByOwnerIdAsync(request.Id, context.CancellationToken);

        getIdsResponse.Ids.AddRange(response.Ids);
        getIdsResponse.Response.Message = response.Response.Message;
        getIdsResponse.Response.Status= response.Response.Status;
        getIdsResponse.Response.Errors.AddRange(response.Response.Errors);

        return getIdsResponse;
    }

    public override async Task<Response> Update(UpsertFileRequest request, ServerCallContext context)
    {
        var response = new Response();

        var file = new FileDTO()
        {
            Id = request.File.Id,
            Url = request.File.Url,
            Type = request.File.Type,
            Extension = request.File.Extension,
            Size = request.File.Size,
            Created = DateTime.Now,
            OwnerId = request.File.OwnerId
        };

        var updateResponse = await _repo.UpdateAsync(file, context.CancellationToken);

        response.Message = updateResponse.Message;
        response.Status = updateResponse.Status;
        response.Errors.AddRange(response.Errors);

        return response;
    }
}