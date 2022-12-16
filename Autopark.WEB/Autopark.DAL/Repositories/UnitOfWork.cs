using Autopark.DAL.EF;
using Autopark.DAL.Interfaces;

namespace Autopark.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RdbmsdbContext _context;
        public virtual ICarShowroomsRepository CarShowroomsRepository { get; }

        public virtual ICarsRepository CarsRepository { get; }

        public virtual ICustomerEmployeeRepository CustomerEmployeeRepository { get; }

        public virtual ICustomerTypesRepository CustomerTypesRepository { get; }

        public virtual IDiscountsRepository DiscountsRepository { get; }

        public virtual IGenerationsRepository GenerationsRepository { get; }

        public virtual ILogsRepository LogsRepository { get; }

        public virtual IManufacturersRepository ManufacturersRepository { get; }

        public virtual IModelsRepository ModelsRepository { get; }

        public virtual IOrdersRepository OrdersRepository { get; }

        public virtual ICarTypesRepository CarTypesRepository { get; set; }

        public virtual IApplicationUserRepository ApplicationUserRepository { get; set; }
        public virtual IVCarsRepository VCarsRepository { get; set; }
        public virtual IVCustomersRepository VCustomersRepository { get; set; }
        public virtual IVEmployeesRepository VEmployeesRepository { get; set; }

        public UnitOfWork(RdbmsdbContext context,
            ICarShowroomsRepository carShowroomsRepository,
            ICarsRepository carsRepository,
            ICustomerEmployeeRepository customerEmployeeRepository,
            ICustomerTypesRepository customerTypesRepository,
            IDiscountsRepository discountsRepository,
            IGenerationsRepository generationsRepository,
            ILogsRepository logsRepository,
            IManufacturersRepository manufacturersRepository,
            IModelsRepository modelsRepository,
            IOrdersRepository ordersRepository,
            ICarTypesRepository carTypesRepository,
            IApplicationUserRepository applicationUserRepository,
            IVCarsRepository vCarsRepository,
            IVCustomersRepository vCustomersRepository,
            IVEmployeesRepository vEmployeesRepository)
        {
            _context = context;

            CarShowroomsRepository = carShowroomsRepository;
            CarsRepository = carsRepository;
            CustomerEmployeeRepository = customerEmployeeRepository;
            CustomerTypesRepository = customerTypesRepository;
            DiscountsRepository = discountsRepository;
            GenerationsRepository = generationsRepository;
            ModelsRepository = modelsRepository;
            OrdersRepository = ordersRepository;
            LogsRepository = logsRepository;
            ManufacturersRepository = manufacturersRepository;
            CarTypesRepository = carTypesRepository;
            ApplicationUserRepository = applicationUserRepository;
            VCarsRepository = vCarsRepository;
            VCustomersRepository = vCustomersRepository;
            VEmployeesRepository = vEmployeesRepository;
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
