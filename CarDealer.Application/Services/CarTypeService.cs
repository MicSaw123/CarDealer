using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class CarTypeService : ICarTypeService
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public CarTypeService(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }
        public async Task<IEnumerable<CarType>> GetCarTypes()
        {
            return await _carTypeRepository.GetAllAsync();

        }

        public async Task<CarType> GetCarTypeById(int carTypeId)
        {
            var carType = await _carTypeRepository.GetByIdAsync(carTypeId);
            return carType;
        }
    }
}
