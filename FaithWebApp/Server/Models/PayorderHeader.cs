using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class PayorderHeader
{
    public int HeaderId { get; set; }

    public string? Description { get; set; }

    public string? PayorderDetail { get; set; }
}
