
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        public void Create(Log entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Log?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Log entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Log>.Create(Log entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Log>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Log>.Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
