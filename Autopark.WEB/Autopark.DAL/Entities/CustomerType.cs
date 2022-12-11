using Autopark.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class CustomerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<ApplicationUser> Users { get; } = new List<ApplicationUser>();
}
