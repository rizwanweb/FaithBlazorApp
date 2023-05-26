using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int BillNo { get; set; }

    public DateTime BillDate { get; set; }

    public int? JobId { get; set; }

    public int SubTotal { get; set; }

    public int? ServiceCharges { get; set; }

    public decimal? SalesTaxRate { get; set; }

    public int? SalesTax { get; set; }

    public int? Total { get; set; }

    public string? Note { get; set; }

    public int? Refund { get; set; }

    public int? Balance { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    public virtual Job? Job { get; set; }

    public virtual ICollection<SalesTaxInvoice> SalesTaxInvoices { get; set; } = new List<SalesTaxInvoice>();
}
