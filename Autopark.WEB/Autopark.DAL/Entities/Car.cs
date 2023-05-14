using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Autopark.WEB.Entities;

public partial class Car
{
    public int Id { get; set; }

    public int CarTypeId { get; set; }

    public int? CarShowroomId { get; set; }

    public int GenerationId { get; set; }

    public double? Price { get; set; }
    public string Vin { get; set; } = null!;

	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	public virtual DateTime? YearOfRelease { get; set; }
    public virtual CarShowroom? CarShowroom { get; set; }

    public virtual CarType? CarType { get; set; }

    public virtual Generation? Generation { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
    public virtual byte[]? Image { get; set; }
}
