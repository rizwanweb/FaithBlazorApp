using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class JobPayorder
{
    public int PayorderId { get; set; }

    public int? JobId { get; set; }

    public string? Particular { get; set; }

    public int? Amount { get; set; }

    public string? Detail { get; set; }

    public virtual Job? Job { get; set; }
}
