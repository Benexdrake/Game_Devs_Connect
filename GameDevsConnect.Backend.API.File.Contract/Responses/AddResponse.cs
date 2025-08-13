namespace GameDevsConnect.Backend.API.File.Contract.Response;

public class AddResponse(string message, bool status, string? id, string[] errors)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public string? Id { get; set; } = id;
}