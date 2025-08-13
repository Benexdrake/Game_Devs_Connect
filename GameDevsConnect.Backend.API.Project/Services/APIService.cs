using GameDevsConnect.Backend.API.Configuration.Application.DTOs;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GameDevsConnect.Backend.API.Project.Services;

public class APIService(IProjectRepository repo) : ProjectProtoService.ProjectProtoServiceBase
{
    private readonly IProjectRepository _repo = repo;

    public override async Task<Response> AddProject(UpsertProjectRequest request, ServerCallContext context)
    {
        var response = new Response();
        var project = new ProjectDTO()
        {
            Id = request.Project.Id,
            Description = request.Project.Description,
            OwnerId = request.Project.OwnerId,
            Title = request.Project.Title
        };

        var upsertProject = new UpsertProject()
        { Project = project };

        var addProjectResponse = await _repo.AddAsync(upsertProject, context.CancellationToken);

        response.Message = addProjectResponse.Message;
        response.Status = addProjectResponse.Status;
        response.Errors.AddRange(addProjectResponse.Errors);

        return response;
    }

    public override async Task<Response> DeleteProject(IdRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteResponse = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Message = deleteResponse.Message;
        response.Status = deleteResponse.Status;
        response.Errors.AddRange(deleteResponse.Errors);

        return response;
    }

    public override async Task<GetProjectResponse> GetProject(IdRequest request, ServerCallContext context)
    {
        var getProjectResponse = new GetProjectResponse();

        var getResponse = await _repo.GetByIdAsync(request.Id, context.CancellationToken);

        getProjectResponse.Response.Message = getResponse.Message;
        getProjectResponse.Response.Status = getResponse.Status;
        getProjectResponse.Response.Errors.AddRange(getResponse.Errors);
        getProjectResponse.Project = new Project()
        {
            Id = getResponse.Project.Id,
            Description = getResponse.Project.Description,
            OwnerId = getResponse.Project.OwnerId,
            Title = getResponse.Project.Title,
        };

        return getProjectResponse;
    }

    public override async Task<GetIdsResponse> GetProjectIds(Empty request, ServerCallContext context)
    {
        var getIdsResponse = new GetIdsResponse();

        var getProjectIdsResponse = await _repo.GetIdsAsync(context.CancellationToken);

        getIdsResponse.Response.Message = getProjectIdsResponse.Message;
        getIdsResponse.Response.Status = getProjectIdsResponse.Status;
        getIdsResponse.Response.Errors.AddRange(getProjectIdsResponse.Errors);
        getIdsResponse.Ids.AddRange(getProjectIdsResponse.Ids);

        return getIdsResponse;
    }

    public override async Task<Response> UpdateProject(UpsertProjectRequest request, ServerCallContext context)
    {
        var response = new Response();

        var project = new ProjectDTO()
        {
            Id = request.Project.Id,
            Description = request.Project.Description,
            OwnerId = request.Project.OwnerId,
            Title = request.Project.Title
        };

        var upsertProject = new UpsertProject()
        { Project = project };

        var updateResponse = await _repo.UpdateAsync(upsertProject, context.CancellationToken);

        response.Message = updateResponse.Message;
        response.Status = updateResponse.Status;
        response.Errors.AddRange(updateResponse.Errors);

        return response;
    }
}