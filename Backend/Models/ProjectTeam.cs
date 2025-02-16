using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class ProjectTeam
{
    public int Id { get; set; }

    public string? Projectid { get; set; }

    public string? Teammemberid { get; set; }
}
