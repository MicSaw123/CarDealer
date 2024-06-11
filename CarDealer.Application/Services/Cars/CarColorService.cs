using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarColorService : ICarColorService
    {
        private readonly ICarColorRepository _carColorRepository;

        public CarColorService(ICarColorRepository carColorRepository)
        {
            _carColorRepository = carColorRepository;
        }

        public async Task<RequestResult<CarColor>> GetCarColorById(int carColorId)
        {
            var result = await _carColorRepository.GetByIdAsync(carColorId);
            if (result is null)
            {
                return RequestResult<CarColor>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<CarColor>.Success(result);
        }

        public async Task<RequestResult<IEnumerable<CarColor>>> GetCarColors()
        {
            var result = await _carColorRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<CarColor>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CarColor>>.Success(result);
        }
    }
}
