using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Repositories
{
    public class CustomerEmployeeRepository : ICustomerEmployeeRepository
    {
        public void Create(CustomerEmployee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerEmployee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerEmployee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerEmployee entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerEmployee>.Create(CustomerEmployee entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerEmployee>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<CustomerEmployee>.Update(CustomerEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}
