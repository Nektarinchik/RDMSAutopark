
using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class CustomerTypesRepository : ICustomerTypesRepository
    {
        private readonly RdbmsdbContext _context;
        public CustomerTypesRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<CustomerType> GetAll()
        {
            return _context.CustomerTypes.FromSqlRaw(
                "SELECT * FROM [dbo].[CustomerTypes]");
        }

        public Task<CustomerType?> GetByIdAsync(int id)
        {
            return _context.CustomerTypes.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[CustomerTypes]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(CustomerType entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC InsertCustomerType {entity.Title}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC DeleteCustomerType {id}");
        }

        public async Task Update(CustomerType entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateCustomerType {entity.Id}, {entity.Title}");
        }
    }
}
