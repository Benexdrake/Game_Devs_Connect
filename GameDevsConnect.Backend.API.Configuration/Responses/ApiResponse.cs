namespace GameDevsConnect.Backend.API.Configuration.Responses;

public class ApiResponse(string message, bool status, string[] validateErrors = null!)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string[] ValidateErrors { get; set; } = validateErrors;
};
