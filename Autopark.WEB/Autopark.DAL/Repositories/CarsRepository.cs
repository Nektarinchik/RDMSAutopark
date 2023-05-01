using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
			using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
			{
				connection.Open();
				using (var cmd = new SqlCommand("InsertCar", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@CarTypeId", entity.CarTypeId);
					cmd.Parameters.AddWithValue("@CarShowroomId", entity.CarShowroomId);
					cmd.Parameters.AddWithValue("@GenerationId", entity.GenerationId);
					cmd.Parameters.AddWithValue("@Price", entity.Price);
					cmd.Parameters.AddWithValue("@Vin", entity.Vin);

					if (entity.Image != null)
					{
						cmd.Parameters.AddWithValue("@Image", entity.Image);
					}

					cmd.ExecuteNonQuery();
				}
			}

			//await _context.Database.ExecuteSqlInterpolatedAsync(
   //             $@"EXEC InsertCar 
   //             {entity.CarTypeId}, {entity.CarShowroomId}, 
   //             {entity.GenerationId}, {entity.Price}, {entity.Vin}, {entity?.Image?.ToString() ?? "NULL"}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
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
			using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
			{
				connection.Open();
				using (var cmd = new SqlCommand("UpdateCar", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", entity.Id);
					cmd.Parameters.AddWithValue("@CarTypeId", entity.CarTypeId);
					cmd.Parameters.AddWithValue("@CarShowroomId", entity.CarShowroomId);
					cmd.Parameters.AddWithValue("@GenerationId", entity.GenerationId);
					cmd.Parameters.AddWithValue("@Price", entity.Price);
					cmd.Parameters.AddWithValue("@Vin", entity.Vin);

					if (entity.Image != null)
					{
						cmd.Parameters.AddWithValue("@Image", entity.Image);
					}

					cmd.ExecuteNonQuery();
				}
			}

			//_ = await _context.Database.ExecuteSqlInterpolatedAsync(
   //             $@"EXEC UpdateCar 
   //             {entity.Id}, {entity.CarTypeId}, {entity.CarShowroomId},
   //             {entity.GenerationId}, {entity.Price}, {entity.Vin}, {entity.Image}");
        }
    }
}
