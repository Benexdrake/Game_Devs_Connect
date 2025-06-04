namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class AddUpdateDeleteResponse(string message, bool status)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
}
