using Autopark.WEB.Entities;

namespace Autopark.DAL.Interfaces
{
    public interface ICustomerEmployeeRepository : IRepositoryCompositeKey<CustomerEmployee>
    {
        public new Task<CustomerEmployee?> GetByIdAsync(int customerId, int employeeId); 
        public new Task Delete(int customerId, int employeeId);

    }
}
