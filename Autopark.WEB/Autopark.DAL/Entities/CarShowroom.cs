using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class CarShowroom
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Rating { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
