using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public int CustomerTypeId { get; set; }

    public double? SpendingBalance { get; set; }

    public virtual ICollection<CustomerEmployee> CustomerEmployees { get; } = new List<CustomerEmployee>();

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual AspNetUser IdNavigation { get; set; } = null!;
}
