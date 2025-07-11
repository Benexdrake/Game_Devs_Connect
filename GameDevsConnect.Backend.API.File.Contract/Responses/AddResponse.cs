namespace GameDevsConnect.Backend.API.File.Contract.Response;

public class AddResponse(string message, bool status, string? id, string[] validationErrors) : ApiResponse(message, status, validationErrors)
{
    public string? Id { get; set; } = id;
}