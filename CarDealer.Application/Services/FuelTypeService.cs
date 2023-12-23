using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class FuelTypeService : IFuelType
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository)
        {
            _fuelTypeRepository = fuelTypeRepository;
        }

        public async Task<IEnumerable<FuelType>> GetFuelTypes()
        {
            return await _fuelTypeRepository.GetAllAsync();
        }

        public async Task<FuelType> GetFuelTypeById(int fuelTypeId)
        {
            var fuelType = await _fuelTypeRepository.GetByIdAsync(fuelTypeId);
            return fuelType;
        }
    }
}
