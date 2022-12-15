using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        private readonly RdbmsdbContext _context;

        public ModelsRepository(RdbmsdbContext context)
        {
            _context = context;
        }
        public IEnumerable<Model> GetAll()
        {
            return _context.Models.FromSqlRaw(
                $@"SELECT * FROM [dbo].[Models]");
        }

        public Task<Model?> GetByIdAsync(int id)
        {
            return _context.Models.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Models]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Model entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertModel {entity.ManufacturerId}, {entity.Title}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteModel {id}");
        }

        public async Task Update(Model entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateModel {entity.Id}, {entity.ManufacturerId}, {entity.Title}");
        }
    }
}
