
using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly RdbmsdbContext _context;
        public LogsRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Log> GetAll()
        {
            return _context.Logs.FromSqlRaw(
                "SELECT * FROM [dbo].[Logs]");
        }

        public Task<Log?> GetByIdAsync(int id)
        {
            return _context.Logs.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Logs]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
