using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class AccountLedger
{
    public int TransactionId { get; set; }

    public DateTime TransactionDate { get; set; }

    public int ClientId { get; set; }

    public string? Particular { get; set; }

    public int Debit { get; set; }

    public int Credit { get; set; }

    public int? Reff { get; set; }

    public string? Drcr { get; set; }

    public virtual CClient Client { get; set; } = null!;
}
