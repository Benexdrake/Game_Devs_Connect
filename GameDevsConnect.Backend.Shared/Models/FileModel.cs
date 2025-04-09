﻿namespace GameDevsConnect.Backend.Shared.Models;

public partial class FileModel
{
    public string Id { get; set; } = null!;

    public string? Description { get; set; }

    public int? Size { get; set; }

    public string? Created { get; set; }

    public string? OwnerId { get; set; }
}
