namespace GameDevsConnect.Backend.API.Configuration.Contract.Responses;

public class ApiResponse(string message, bool status, string[] errors = null!)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[] Errors { get; set; } = errors;
};
