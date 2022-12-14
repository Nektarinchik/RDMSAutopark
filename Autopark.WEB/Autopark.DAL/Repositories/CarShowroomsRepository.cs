using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
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
        public void Create(CarShowroom entity)
        {
            _ = _context.CarShowrooms.FromSqlInterpolated(
                $@"EXEC InsertCarShowroom 
                {entity.Title}, {entity.Rating}, {entity.Phone}");
        }

        public void Delete(int id)
        {
            _ = _context.CarShowrooms.FromSqlInterpolated(
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

        public void Update(CarShowroom entity)
        {
            _ = _context.CarShowrooms.FromSqlInterpolated(
                $@"EXEC UpdateCarShowroom 
                {entity.Id}, {entity.Title}, {entity.Rating}, {entity.Phone}");
        }
    }
}
