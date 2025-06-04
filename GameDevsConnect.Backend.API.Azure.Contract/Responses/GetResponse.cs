namespace GameDevsConnect.Backend.API.Azure.Contract.Responses;

public class GetResponse(string message, bool status, string fileUrl)
{
    public string Message { get; set; } = message;
    public bool Status { get; set; } = status;
    public string FileUrl { get; set; } = fileUrl;
}
