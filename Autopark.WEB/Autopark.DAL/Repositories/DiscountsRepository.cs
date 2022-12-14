
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class DiscountsRepository : IDiscountsRepository
    {
        public void Create(Discount entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Discount?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Discount entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Discount>.Create(Discount entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Discount>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Discount>.Update(Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
