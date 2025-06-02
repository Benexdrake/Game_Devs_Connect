using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.Shared.DTO;
public class AddRequestTagsDTO
{
    public RequestModel Request { get; set; }
    public TagModel[] Tags { get; set; }
}
