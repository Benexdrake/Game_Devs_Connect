using GameDevsConnect.Backend.Shared.Responses;

namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetIdsByUserIdResponse(string message, bool status, string[] ids) : ApiResponse(message, status)
{
    public string[] Ids { get; set; } = ids;
}
