using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarTypeService : ICarTypeService
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public CarTypeService(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }
        public async Task<RequestResult<IEnumerable<CarType>>> GetCarTypes()
        {
            var carTypes = await _carTypeRepository.GetAllAsync();
            if (carTypes is null)
            {
                return RequestResult<IEnumerable<CarType>>.Failure(Error.ErrorUnknown);
            }

            return RequestResult<IEnumerable<CarType>>.Success(carTypes);

        }

        public async Task<RequestResult<CarType>> GetCarTypeById(int carTypeId)
        {
            var carType = await _carTypeRepository.GetByIdAsync(carTypeId);
            if (carType is null)
            {
                return RequestResult<CarType>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<CarType>.Success(carType);
        }

        public async Task<RequestResult> Add(CarType carType)
        {

            await _carTypeRepository.Add(carType);
            await _carTypeRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteCarType(int id)
        {
            var result = await _carTypeRepository.GetByIdAsync(id);
            await _carTypeRepository.Delete(result);
            await _carTypeRepository.SaveChangesAsync();
            return RequestResult.Success();
        }
    }
}
