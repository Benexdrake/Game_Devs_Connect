namespace GameDevsConnect.Backend.Shared.Responses;

public class ApiResponse(string message, bool status)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
};
