using GameDevsConnect.Backend.Shared.Models;

namespace GameDevsConnect.Backend.API.Project.Contract.Requests;

public class UpsertRequest
{
    public ProjectModel? Project { get; set; }
    // Fehlt noch der Content aus dem Project Builder
}
