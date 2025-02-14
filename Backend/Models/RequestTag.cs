using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class RequestTag
{
    public int Id { get; set; }
    public string? RequestId { get; set; }

    public string? Tagname { get; set; }
}
