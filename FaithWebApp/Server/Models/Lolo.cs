using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Lolo
{
    public int LoloId { get; set; }

    public string? LoloName { get; set; }

    public string? ShortName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Pid> Pids { get; set; } = new List<Pid>();
}
