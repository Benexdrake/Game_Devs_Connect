using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Project.Contract.Responses;

public class GetResponse(string message, bool status, ProjectModel project) : ApiResponse(message, status)
{
    public ProjectModel Project { get; set; } = project;
}
