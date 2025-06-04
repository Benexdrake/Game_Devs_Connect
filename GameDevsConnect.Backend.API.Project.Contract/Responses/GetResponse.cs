using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Project.Contract.Responses;

public class GetResponse(string message, bool status, ProjectModel project)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public ProjectModel Project { get; set; } = project;
}
