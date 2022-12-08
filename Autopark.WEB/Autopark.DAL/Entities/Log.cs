using Autopark.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Autopark.WEB.Entities;

public partial class Log
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime LogTime { get; set; }

    public string LogMessage { get; set; } = null!;

    public virtual CustomerUser? CustomerUser { get; set; }
}
