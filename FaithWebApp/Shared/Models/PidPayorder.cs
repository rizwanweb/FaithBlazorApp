using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class PidPayorder
{
    public int PayorderId { get; set; }

    public int? PidId { get; set; }

    public string? Particular { get; set; }

    public int? Amount { get; set; }

    public string? Detail { get; set; }

    public virtual Pid? Pid { get; set; }
}
