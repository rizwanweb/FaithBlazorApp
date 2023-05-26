using System;
using System.Collections.Generic;

namespace FaithWebApp.Server.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
