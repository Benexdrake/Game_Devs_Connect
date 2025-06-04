namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class AddUpdateDeleteUserResponse(string message, bool status)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
}
