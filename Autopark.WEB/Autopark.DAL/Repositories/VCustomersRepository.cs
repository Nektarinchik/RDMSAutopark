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
    public class VCustomersRepository : IVCustomersRepository
    {
        private readonly RdbmsdbContext _context;
        public VCustomersRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<VCustomer> GetAll()
        {
            return _context.VCustomers.FromSqlRaw(
                "SELECT * FROM [dbo].[vCustomers]");
        }

        public Task<VCustomer?> GetByIdAsync(int id)
        {
            return _context.VCustomers.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[vCustomers]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
