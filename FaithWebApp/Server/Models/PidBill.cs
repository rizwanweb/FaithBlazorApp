using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class PidBill
{
    public int BillId { get; set; }

    public int BillNo { get; set; }

    public DateTime BillDate { get; set; }

    public int? PidId { get; set; }

    public int? Total { get; set; }

    public int? Refund { get; set; }

    public int? Balance { get; set; }

    public string? Note { get; set; }

    public virtual Pid? Pid { get; set; }

    public virtual ICollection<PidBillDetail> PidBillDetails { get; set; } = new List<PidBillDetail>();
}
