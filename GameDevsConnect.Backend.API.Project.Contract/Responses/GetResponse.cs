namespace GameDevsConnect.Backend.API.Project.Contract.Responses;

public class GetResponse(string message, bool status, ProjectModel project) : ApiResponse(message, status)
{
    public ProjectModel Project { get; set; } = project;
}
