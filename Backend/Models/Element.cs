using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Element
{
    public string Id { get; set; } = null!;

    public int? Elementtype { get; set; }

    public string? Content { get; set; }

    public string? Config { get; set; }

    public int? Nr { get; set; }

    public string? Projectid { get; set; }
}
