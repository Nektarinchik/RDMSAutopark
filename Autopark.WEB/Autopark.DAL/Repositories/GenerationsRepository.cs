
using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.Repositories
{
    public class GenerationsRepository : IGenerationsRepository
    {
        private readonly RdbmsdbContext _context;

        public GenerationsRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Generation> GetAll()
        {
            return _context.Generations.FromSqlRaw(
                "SELECT * FROM [dbo].[Generations]");
        }

        public Task<Generation?> GetByIdAsync(int id)
        {
            return _context.Generations.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[Generations]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Generation entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC InsertGeneration {entity.ModelId}, {entity.Title}");
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteGeneration {id}");
        }

        public async Task Update(Generation entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateGeneration {entity.Id}, {entity.ModelId}, {entity.Title}");
        }
    }
}
