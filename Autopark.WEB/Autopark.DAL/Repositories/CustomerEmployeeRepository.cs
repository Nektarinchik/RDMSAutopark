using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Repositories
{
    public class CustomerEmployeeRepository : ICustomerEmployeeRepository
    {
        private readonly RdbmsdbContext _context;
        public CustomerEmployeeRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerEmployee entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC InsertCustomerEmployee {entity.CustomerId}, {entity.EmployeeId}");
        }

        public async Task Delete(int customerId, int employeeId)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC DeleteCustomerEmployee {customerId}, {employeeId}");
        }

        public IEnumerable<CustomerEmployee> GetAll()
        {
            return _context.CustomerEmployees.FromSqlRaw(
                "SELECT * FROM [dbo].[CustomerEmployee]");
        }

        public Task<CustomerEmployee?> GetByIdAsync(int customerId, int employeeId)
        {
            return _context.CustomerEmployees.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[CustomerEmployee]
                WHERE CustomerId = {customerId} AND EmployeeId = {employeeId}").
                FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(CustomerEmployee entity)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"EXEC UpdateCustomerEmployee {entity.Id}, {entity.CustomerId}, {entity.EmployeeId}");
        }
    }
}
