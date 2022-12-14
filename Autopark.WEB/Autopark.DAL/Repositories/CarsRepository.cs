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
        public void Create(Car entity)
        {
            _ = _context.Cars.FromSqlInterpolated(
                $@"EXEC InsertCar 
                {entity.CarTypeId}, {entity.CarShowroomId}, 
                {entity.GenerationId}, {entity.Price}, {entity.Vin}");
        }

        public void Delete(int id)
        {
            _ = _context.Cars.FromSqlInterpolated(
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

        public void Update(Car entity)
        {
            _ = _context.Cars.FromSqlInterpolated(
                $@"EXEC UpdateCar 
                {entity.Id}, {entity.CarTypeId}, {entity.CarShowroomId},
                {entity.GenerationId}, {entity.Price}, {entity.Vin}");
        }
    }
}
