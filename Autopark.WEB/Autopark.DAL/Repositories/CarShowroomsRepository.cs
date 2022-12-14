using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class CarShowroomsRepository : ICarShowroomsRepository
    {
        private readonly RdbmsdbContext _context;
        public CarShowroomsRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        public async Task Create(CarShowroom entity)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertCarShowroom 
                {entity.Title}, {entity.Rating}, {entity.Phone}");
        }

        public async Task Delete(int id)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteCarShowroom {id}");          
        }

        public IEnumerable<CarShowroom> GetAll()
        {
            return _context.CarShowrooms.FromSqlRaw(
                "SELECT * FROM [dbo].[CarShowrooms]");
        }

        public Task<CarShowroom?> GetByIdAsync(int id)
        {
            return _context.CarShowrooms.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[CarShowrooms] 
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(CarShowroom entity)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateCarShowroom 
                {entity.Id}, {entity.Title}, {entity.Rating}, {entity.Phone}");
        }
    }
}
