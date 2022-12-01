using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerEmployeeId { get; set; }

    public int? DiscountId { get; set; }

    public int? CarId { get; set; }

    public DateTime Date { get; set; }

    public virtual Car? Car { get; set; }

    public virtual CustomerEmployee? CustomerEmployee { get; set; }

    public virtual Discount? Discount { get; set; }
}
