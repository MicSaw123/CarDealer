using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class FuelTypeService : IFuelType
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository)
        {
            _fuelTypeRepository = fuelTypeRepository;
        }

        public async Task<RequestResult<IEnumerable<FuelType>>> GetFuelTypes()
        {
            var fuelTypes = await _fuelTypeRepository.GetAllAsync();
            if (fuelTypes is null)
            {
                return RequestResult<IEnumerable<FuelType>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<FuelType>>.Success(fuelTypes);
        }

        public async Task<FuelType> GetFuelTypeById(int fuelTypeId)
        {
            var fuelType = await _fuelTypeRepository.GetByIdAsync(fuelTypeId);
            return fuelType;
        }
    }
}
