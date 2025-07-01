using GameDevsConnect.Backend.API.Configuration.Application.DTOs;
using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.File.Contract.Responses;
public class GetByIdResponse(string message, bool status, FileDTO file) : ApiResponse(message, status)
{
    public FileDTO File { get; set; } = file;
}
