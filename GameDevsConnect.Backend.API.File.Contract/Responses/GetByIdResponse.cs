namespace GameDevsConnect.Backend.API.File.Contract.Responses;
public class GetByIdResponse(string message, bool status, FileDTO file) : ApiResponse(message, status)
{
    public FileDTO File { get; set; } = file;
}
