namespace GameDevsConnect.Backend.API.Project.Contract.Responses;

public class GetResponse(string message, bool status, ProjectDTO project, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public ProjectDTO Project { get; set; } = project;
}
