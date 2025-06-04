namespace GameDevsConnect.Backend.API.Gateway.Contract.Responses;

public class AuthenticateResponse(string message, bool success)
{
    public string Message { get; set; } = message;
    public bool Success { get; set; } = success;
}
