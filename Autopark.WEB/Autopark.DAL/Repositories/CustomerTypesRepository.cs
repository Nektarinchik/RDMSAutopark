
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.DAL.Repositories
{
    public class CustomerTypesRepository : ICustomerTypesRepository
    {
        public void Create(CustomerType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerType> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerType?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerType entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerType>.Create(CustomerType entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerType>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerType>.Update(CustomerType entity)
        {
            throw new NotImplementedException();
        }
    }
}
