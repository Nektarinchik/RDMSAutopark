using Autopark.DAL.Interfaces;
using Autopark.WEB.Entities;

namespace Autopark.WEB.ViewModels.Cars
{
    public class IndexDetailCarsViewModel : Car
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Car _car;
        public override CarShowroom? CarShowroom
        {
            get
            {
                if (_car.CarShowroomId.HasValue)
                {
                    return _unitOfWork.CarShowroomsRepository.
                        GetByIdAsync(_car.CarShowroomId.Value).
                        Result;
                }
                return null;
            }

            set => base.CarShowroom = value;
        }
        public override byte[]? Image { get => _car.Image; set => _car.Image = value; }

		public override DateTime? YearOfRelease { get => _car.YearOfRelease; set => _car.YearOfRelease = value; }
		public override CarType? CarType
        {
            get
            {
                return _unitOfWork.CarTypesRepository.
                    GetByIdAsync(_car.CarTypeId).
                    Result;
            }
            set => base.CarType = value;
        }
        public override Generation? Generation
        {
            get
            {
                Generation? generation = _unitOfWork.GenerationsRepository.
                    GetByIdAsync(_car.GenerationId).
                    Result;
                if (!ReferenceEquals(generation, null))
                {
                    generation.Model = _unitOfWork.ModelsRepository.
                        GetByIdAsync(generation.ModelId).
                        Result;
                    if (!ReferenceEquals(generation.Model, null))
                    {
                        generation.Model.Manufacturer = _unitOfWork.ManufacturersRepository.
                            GetByIdAsync(generation.Model.ManufacturerId).
                            Result;
                    }

                    return generation;
                }

                return null;
            }
            set => base.Generation = value;
        }
        public IndexDetailCarsViewModel(IUnitOfWork unitOfWork, Car car)
        {
            _unitOfWork = unitOfWork;
            _car = car;
            Id = car.Id;
            CarTypeId = car.CarTypeId;
            CarShowroomId = car.CarShowroomId;
            GenerationId = car.GenerationId;
            Price = car.Price;
            Vin = car.Vin;
        }
    }
}
