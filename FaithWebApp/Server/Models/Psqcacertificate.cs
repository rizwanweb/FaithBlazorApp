using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Psqcacertificate
{
    public int Psqcid { get; set; }

    public int? JobId { get; set; }

    public string? Invoice { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? Origin { get; set; }

    public string? Brand { get; set; }

    public int? AuthorizedPerson { get; set; }

    public virtual PsqcauthPerson? AuthorizedPersonNavigation { get; set; }
}
