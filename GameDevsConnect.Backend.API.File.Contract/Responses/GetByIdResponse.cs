namespace GameDevsConnect.Backend.API.File.Contract.Responses;
public class GetByIdResponse(string message, bool status, FileDTO file, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public FileDTO File { get; set; } = file;
}
