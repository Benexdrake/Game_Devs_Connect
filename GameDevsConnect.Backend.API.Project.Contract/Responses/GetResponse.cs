namespace GameDevsConnect.Backend.API.Project.Contract.Responses;

public class GetResponse(string message, bool status, ProjectDTO project) : ApiResponse(message, status)
{
    public ProjectDTO Project { get; set; } = project;
}
