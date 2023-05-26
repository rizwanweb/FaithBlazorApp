using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaithWebApp.Server.Models;

public class CClient
{
    [Key]
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Ntn { get; set; }

    public string? Gst { get; set; }

    public string? Address { get; set; }

    public City City { get; set; }
    public int CityID { get; set; }

    public string? ClientType { get; set; }

    public string? Fax { get; set; }

    public string? StandAddress { get; set; }

    public string? Cnic { get; set; }

    public string? Designation { get; set; }

    public string? AuthorizedPerson { get; set; }

    public virtual ICollection<AccountLedger> AccountLedgers { get; set; } = new List<AccountLedger>();

    //public virtual City CityNavigation { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Pid> Pids { get; set; } = new List<Pid>();
}
