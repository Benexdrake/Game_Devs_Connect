using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Project
{
    public string Id { get; set; } = null!;

    public string? Headerimage { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Ownerid { get; set; }
}
