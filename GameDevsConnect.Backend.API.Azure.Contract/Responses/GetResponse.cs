namespace GameDevsConnect.Backend.API.Azure.Contract.Responses;

public class GetResponse(string message, bool status, string fileUrl) : ApiResponse(message, status)
{
    public string FileUrl { get; set; } = fileUrl;
}
