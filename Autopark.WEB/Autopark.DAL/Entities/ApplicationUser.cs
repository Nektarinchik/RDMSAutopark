﻿using Autopark.WEB.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int? CustomerTypeId { get; set; }
        public double? SpendingBalance { get; set; }

        public virtual CustomerType CustomerType { get; set; } = null!;
        public virtual ICollection<CustomerEmployee> CustomerEmployees => CustomerEmployees1.Concat(CustomerEmployees2).Distinct().ToList();
        public virtual ICollection<Log> Logs { get; } = new List<Log>();
        private ICollection<CustomerEmployee> CustomerEmployees1 { get; set; } = new List<CustomerEmployee>();
        private ICollection<CustomerEmployee> CustomerEmployees2 { get; set; } = new List<CustomerEmployee>();
    } 
}