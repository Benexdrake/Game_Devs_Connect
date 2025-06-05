using GameDevsConnect.Backend.Shared.Models;
using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.File.Contract.Responses;
public class GetByIdResponse(string message, bool status, FileModel file) : ApiResponse(message, status)
{
    public FileModel File { get; set; } = file;
}
