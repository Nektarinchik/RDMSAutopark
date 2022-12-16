using Autopark.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class CustomerEmployee
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public virtual ApplicationUser Customer { get; set; } = null!;
    public virtual ApplicationUser Employee { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
