using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class BillDetail
{
    public int BillDetailsId { get; set; }

    public int? BillId { get; set; }

    public string? Particulars { get; set; }

    public string? ReceiptNo { get; set; }

    public int? ByYou { get; set; }

    public int? ByUs { get; set; }

    public virtual Bill? Bill { get; set; }
}
