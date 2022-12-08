using Autopark.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<CustomerEmployee> CustomerEmployees { get; } = new List<CustomerEmployee>();

    public virtual CustomerUser IdNavigation { get; set; } = null!;
}
