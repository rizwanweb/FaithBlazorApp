using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class City
{
    [System.ComponentModel.DataAnnotations.Key]
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<CClient> Clients { get; set; } = new List<CClient>();
}
