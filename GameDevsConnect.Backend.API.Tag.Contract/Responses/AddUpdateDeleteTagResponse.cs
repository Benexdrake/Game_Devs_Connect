namespace GameDevsConnect.Backend.API.Tag.Contract.Responses;

public class AddUpdateDeleteTagResponse(string message, bool status)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
}
