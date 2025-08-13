namespace GameDevsConnect.Backend.API.Notification.Contract.Responses;

public class GetIdsByUserIdResponse(string message, bool status, string[] ids, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public string[] Ids { get; set; } = ids;
}
