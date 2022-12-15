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
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly RdbmsdbContext _context;
        public ApplicationUserRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users.FromSqlRaw(
                "SELECT * FROM [dbo].[AspNetUsers]");
        }

        public Task<ApplicationUser?> GetByIdAsync(int id)
        {
            return _context.Users.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[AspNetUsers]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
