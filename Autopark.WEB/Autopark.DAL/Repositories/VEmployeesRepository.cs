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
    public class VEmployeesRepository : IVEmployeesRepository
    {
        private readonly RdbmsdbContext _context;
        public VEmployeesRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<VEmployee> GetAll()
        {
            return _context.VEmployees.FromSqlRaw(
                "SELECT * FROM [dbo].[vEmployees]");
        }

        public Task<VEmployee?> GetByIdAsync(int id)
        {
            return _context.VEmployees.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[vEmployees]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
