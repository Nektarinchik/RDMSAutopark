using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.WEB.ViewModels.Cars
{
    public class CreateUpdateCarsViewModel
    {
        public IEnumerable<CarShowroom> CarShowrooms { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
        public IEnumerable<Generation> Generations { get; set; }
        public CreateUpdateCarsViewModel(IUnitOfWork unitOfWork)
        {
            CarShowrooms = unitOfWork.CarShowroomsRepository.GetAll();
            CarTypes = unitOfWork.CarTypesRepository.GetAll();
            var generations = unitOfWork.GenerationsRepository.GetAll();
            Manufacturer? manufacturer = null;
            Model? model = null;
            foreach (var generation in generations)
            {
                model = unitOfWork.ModelsRepository.
                    GetByIdAsync(generation.ModelId).
                    Result;
                if (!ReferenceEquals(model, null))
                {
                    manufacturer = unitOfWork.ManufacturersRepository.
                        GetByIdAsync(model.ManufacturerId).
                        Result;
                }
                generation.Title = manufacturer?.Title + " " + model?.Title + " " + generation.Title;
            }
            Generations = generations;
        }

    }
}
