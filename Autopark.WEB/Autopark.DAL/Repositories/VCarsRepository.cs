using Autopark.DAL.EF;
using Autopark.DAL.Entities;
using Autopark.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Repositories
{
    public class VCarsRepository : IVCarsRepository
    {
        private readonly RdbmsdbContext _context;
        public VCarsRepository(RdbmsdbContext context)
        {
            _context = context;
        }

        public IEnumerable<VCar> GetAll()
        {
            return _context.VCars.FromSqlRaw(
                "SELECT * FROM [dbo].[vCars]");
        }

        public Task<VCar?> GetByIdAsync(int id)
        {
            return _context.VCars.FromSqlInterpolated(
                $@"SELECT * FROM [dbo].[vCars]
                WHERE Id = {id}").FirstOrDefaultAsync();
        }
    }
}
