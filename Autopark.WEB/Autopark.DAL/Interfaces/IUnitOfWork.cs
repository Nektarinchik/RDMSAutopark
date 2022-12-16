using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICarShowroomsRepository CarShowroomsRepository { get; }
        public ICarsRepository CarsRepository { get; }
        public ICustomerEmployeeRepository CustomerEmployeeRepository { get; }
        public ICustomerTypesRepository CustomerTypesRepository { get; }
        public IDiscountsRepository DiscountsRepository { get; }
        public IGenerationsRepository GenerationsRepository { get; }
        public ILogsRepository LogsRepository { get; }
        public IManufacturersRepository ManufacturersRepository { get; }
        public IModelsRepository ModelsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }
        public ICarTypesRepository CarTypesRepository { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set; }
        public IVCarsRepository VCarsRepository { get; set; }
        public IVCustomersRepository VCustomersRepository { get; set; }
        public IVEmployeesRepository VEmployeesRepository { get; set; }
        public IVOrdersRepository VOrdersRepository { get; set; }
        public Task SaveAsync();
    }
}
