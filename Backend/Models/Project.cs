using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Project
{
    public string Id { get; set; } = string.Empty;

    public string Headerimage { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Ownerid { get; set; } = string.Empty;
}
