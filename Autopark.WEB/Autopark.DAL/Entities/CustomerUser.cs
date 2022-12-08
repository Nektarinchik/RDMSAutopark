using Autopark.WEB.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Entities
{
    public class CustomerUser : IdentityUser<int>
    {
        public int? CustomerTypeId { get; set; }
        public double? SpendingBalance { get; set; }

        public virtual CustomerType CustomerType { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<CustomerEmployee> CustomerEmployees { get; set; } = new List<CustomerEmployee>();
        public virtual ICollection<Log> Logs { get; } = new List<Log>();
    } 
}
