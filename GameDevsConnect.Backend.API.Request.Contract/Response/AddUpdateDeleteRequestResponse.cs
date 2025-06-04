namespace GameDevsConnect.Backend.API.Request.Contract.Response;

public class AddUpdateDeleteRequestResponse(string message, bool status)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
}
