using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly RdbmsdbContext _context;
        public CarsRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        public async Task Create(Car entity)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertCar 
                {entity.CarTypeId}, {entity.CarShowroomId}, 
                {entity.GenerationId}, {entity.Price}, {entity.Vin}");
        }

        public async Task Delete(int id)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                    $@"EXEC DeleteCar {id}"); 
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Cars]");
        }

        public Task<Car?> GetByIdAsync(int id)
        {
            return _context.Cars.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Cars]
                WHERE Id = {id}").
                FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Car entity)
        {
            _ = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateCar 
                {entity.Id}, {entity.CarTypeId}, {entity.CarShowroomId},
                {entity.GenerationId}, {entity.Price}, {entity.Vin}");
        }
    }
}
