using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Entities
{
    public class VOrder
    {
        public int Id { get; set; }
        public string? DiscountTitle { get; set; }
        public string? CarTitle { get; set; }
        public string? CustomerTitle { get; set; }
        public string? EmployeeTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
