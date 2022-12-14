using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class ManufacturersRepository : IManufacturersRepository
    {
        public void Create(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Manufacturer>.Create(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Manufacturer>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Manufacturer>.Update(Manufacturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
