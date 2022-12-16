using Autopark.WEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.IEnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        public static async Task<T?> FirstOrDefaultAsync<T>(this IEnumerable<T> arr)
        {
            await Task.Delay(0);
            return arr.FirstOrDefault();
        }
    }
}
