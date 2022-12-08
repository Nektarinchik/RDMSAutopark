using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Car
{
    public int Id { get; set; }

    public int CarTypeId { get; set; }

    public int? CarShowroomId { get; set; }

    public int GenerationId { get; set; }

    public double? Price { get; set; }
    public string Vin { get; set; } = null!;
    public virtual CarShowroom? CarShowroom { get; set; }

    public virtual CarType CarType { get; set; } = null!;

    public virtual Generation Generation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
