namespace GameDevsConnect.Backend.Shared.Models;

public class APIResponse(bool status, object data)
{
    public bool Status { get; set; } = status;
    public object Data { get; set; } = data;
}
