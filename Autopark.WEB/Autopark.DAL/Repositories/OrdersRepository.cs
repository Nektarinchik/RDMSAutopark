using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly RdbmsdbContext _context;
        public OrdersRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.FromSqlRaw(
                "SELECT * FROM [dbo].[Orders]");
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            return _context.Orders.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Orders]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Order entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertOrder {entity.CustomerEmployeeId}, 
                {entity.CarId}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteOrder {id}");
        }

        public async Task Update(Order entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateOrder {entity.Id}, {entity.CustomerEmployeeId}, 
                {entity.DiscountId}, {entity.CarId}, {entity.Date}");
        }
    }
}
