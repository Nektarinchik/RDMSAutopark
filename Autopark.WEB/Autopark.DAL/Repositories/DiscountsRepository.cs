
using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class DiscountsRepository : IDiscountsRepository
    {
        private readonly RdbmsdbContext _context;
        public DiscountsRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Discount> GetAll()
        {
            return _context.Discounts.FromSqlRaw(
                "SELECT * FROM [dbo].[Discounts]");
        }

        public Task<Discount?> GetByIdAsync(int id)
        {
            return _context.Discounts.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Discounts]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Create(Discount entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertDiscount {entity.Title}, {entity.Value}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteDiscount {id}");
        }

        public async Task Update(Discount entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateDiscount {entity.Id}, {entity.Title}, {entity.Value}");
        }
    }
}
