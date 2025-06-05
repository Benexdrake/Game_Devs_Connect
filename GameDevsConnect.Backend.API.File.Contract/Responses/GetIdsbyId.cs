using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.File.Contract.Responses;

public class GetIdsbyId(string message, bool status, string[] ids) : ApiResponse(message, status)
{
    public string[] Ids { get; set; } = ids;
}
