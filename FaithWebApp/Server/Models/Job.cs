using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int JobNo { get; set; }

    public DateTime JobDate { get; set; }

    public int Client { get; set; }

    public string? Lc { get; set; }

    public DateTime? Lcdate { get; set; }

    public int? Item { get; set; }

    public string? ItemDetail { get; set; }

    public int? Containers { get; set; }

    public int? Size { get; set; }

    public string? Packages { get; set; }

    public string? Vessel { get; set; }

    public string? Bl { get; set; }

    public DateTime? Bldate { get; set; }

    public int? Igm { get; set; }

    public DateTime? Igmdate { get; set; }

    public int? IndexNo { get; set; }

    public int? Quantity { get; set; }

    public decimal InvoiceValueUsd { get; set; }

    public decimal ExchangeRate { get; set; }

    public int? ValueInPkr { get; set; }

    public int? Insurance { get; set; }

    public int? LandingCharges { get; set; }

    public int? ImportValuePkr { get; set; }

    public int? CustomDuty { get; set; }

    public string? CustomDutyType { get; set; }

    public decimal? CustomDutyRate { get; set; }

    public int? AddCustomDuty { get; set; }

    public string? AddCustomDutyType { get; set; }

    public decimal? AddCustomDutyRate { get; set; }

    public int? SalesTax { get; set; }

    public string? SalesTaxType { get; set; }

    public decimal? SalesTaxRate { get; set; }

    public int? IncomeTax { get; set; }

    public string? IncomeTaxType { get; set; }

    public decimal? IncomeTaxRate { get; set; }

    public int? Cess { get; set; }

    public string? CessType { get; set; }

    public decimal? CessRate { get; set; }

    public int? Rd { get; set; }

    public string? Rdtype { get; set; }

    public decimal? Rdrate { get; set; }

    public int? TotalDuty { get; set; }

    public int? Terminal { get; set; }

    public int? ShippingLine { get; set; }

    public int? Lolo { get; set; }

    public string? Gd { get; set; }

    public DateTime? Gddate { get; set; }

    public string? Cash { get; set; }

    public DateTime? CashDate { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual CClient ClientNavigation { get; set; } = null!;

    public virtual Item? ItemNavigation { get; set; }

    public virtual ICollection<JobPayorder> JobPayorders { get; set; } = new List<JobPayorder>();

    public virtual Lolo? LoloNavigation { get; set; }

    public virtual ShippingLine? ShippingLineNavigation { get; set; }

    public virtual Terminal? TerminalNavigation { get; set; }
}
