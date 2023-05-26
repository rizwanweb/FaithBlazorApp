using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class SalesTaxInvoice
{
    public int Stid { get; set; }

    public int? SalesTaxNo { get; set; }

    public DateTime? Stdate { get; set; }

    public int? BillId { get; set; }

    public decimal? Rate { get; set; }

    public int? SalesTax { get; set; }

    public virtual Bill? Bill { get; set; }
}
