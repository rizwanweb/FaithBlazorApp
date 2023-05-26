using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class PsqcauthPerson
{
    public int PersonId { get; set; }

    public string? Name { get; set; }

    public string? Nic { get; set; }

    public string? FatherName { get; set; }

    public virtual ICollection<Psqcacertificate> Psqcacertificates { get; set; } = new List<Psqcacertificate>();
}
