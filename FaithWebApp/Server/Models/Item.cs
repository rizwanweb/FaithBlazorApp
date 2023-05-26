using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string Hscode { get; set; } = null!;

    public decimal? CustomDuty { get; set; }

    public int? CustomDutyType { get; set; }

    public decimal? AddCustomDuty { get; set; }

    public int? AddCustomDutyType { get; set; }

    public decimal? SalesTax { get; set; }

    public decimal? IncomeTax { get; set; }

    public decimal? Cess { get; set; }

    public int? CessType { get; set; }

    public decimal? Rd { get; set; }

    public int? Rdtype { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Pid> Pids { get; set; } = new List<Pid>();
}
