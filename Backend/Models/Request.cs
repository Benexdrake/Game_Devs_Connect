using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Request
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Fileurl { get; set; }

    public string? Created { get; set; }

    public string? ProjectId { get; set; }

    public string? UserId { get; set; }
}
