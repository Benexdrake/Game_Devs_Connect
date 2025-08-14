namespace GameDevsConnect.Backend.API.Gateway.Application.Models;

public class APIEndpoint(string name, string url)
{
    public string Name { get; set; } = name;
    public string Url { get; set; } = url;
}
