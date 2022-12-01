using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
