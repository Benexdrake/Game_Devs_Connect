using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Comment.Contract.Responses;

public class GetCountByRequestId(string message, bool status, int count) : ApiResponse(message, status)
{
    public int Count { get; set; } = count;
}
