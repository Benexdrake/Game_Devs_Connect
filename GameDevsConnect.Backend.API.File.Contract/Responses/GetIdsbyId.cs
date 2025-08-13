namespace GameDevsConnect.Backend.API.File.Contract.Responses;

public class GetIdsbyId(string message, bool status, string[] ids, string[] errors = default!)
{
    public ApiResponse Response { get; set; } = new ApiResponse(message, status, errors);
    public string[] Ids { get; set; } = ids;
}
