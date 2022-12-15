using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class ManufacturersRepository : IManufacturersRepository
    {
        private readonly RdbmsdbContext _context;
        public ManufacturersRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manufacturers.FromSqlRaw(
                $@"SELECT * FROM [dbo].[Manufacturers]");
        }

        public Task<Manufacturer?> GetByIdAsync(int id)
        {
            return _context.Manufacturers.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Manufacturers]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Create(Manufacturer entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertManufacturer {entity.Title}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteManufacturer {id}");
        }

        public async Task Update(Manufacturer entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateManufacturer {entity.Id}, {entity.Title}");
        }
    }
}
