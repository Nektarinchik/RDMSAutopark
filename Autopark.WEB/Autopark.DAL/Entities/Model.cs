using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Model
{
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Generation> Generations { get; } = new List<Generation>();

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
