using Autopark.DAL.EF;
using Autopark.DAL.Entities;
using Autopark.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Repositories
{
    public class VOrdersRepository : IVOrdersRepository
    {
        private readonly RdbmsdbContext _context;
        public VOrdersRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<VOrder> GetAll()
        {
            return _context.VOrders.FromSqlRaw(
                "SELECT * FROM [dbo].[vOrders]");
        }

        public Task<VOrder?> GetByIdAsync(int id)
        {
            return _context.VOrders.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[vOrders]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
