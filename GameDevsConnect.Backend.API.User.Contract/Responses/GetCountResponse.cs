using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.User.Contract.Responses;

public class GetCountResponse(string message, bool status, int count) : ApiResponse(message, status)
{
    public int Count { get; set; } = count;
}
