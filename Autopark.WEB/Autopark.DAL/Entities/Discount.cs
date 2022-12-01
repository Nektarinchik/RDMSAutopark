using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Value { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
