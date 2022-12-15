using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class CarTypesRepository : ICarTypesRepository
    {
        private readonly RdbmsdbContext _context;
        public CarTypesRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public async Task Create(CarType entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC InsertCarType {entity.Title}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC DeleteCarType {id}");
        }

        public IEnumerable<CarType> GetAll()
        {
            return _context.CarTypes.FromSqlRaw(
                "SELECT * FROM [dbo].[CarTypes]");
        }

        public Task<CarType?> GetByIdAsync(int id)
        {
            return _context.CarTypes.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[CarTypes]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(CarType entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateCarType {entity.Id}, {entity.Title}");
        }
    }
}
