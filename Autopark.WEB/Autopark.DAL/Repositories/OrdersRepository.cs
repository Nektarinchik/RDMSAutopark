using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public void Create(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
