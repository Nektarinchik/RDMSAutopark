using Autopark.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class CustomerEmployee
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerUserId { get; set; }

    public virtual CustomerUser Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
