using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        public void Create(Model entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Model?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Model entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Model>.Create(Model entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Model>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Model>.Update(Model entity)
        {
            throw new NotImplementedException();
        }
    }
}
