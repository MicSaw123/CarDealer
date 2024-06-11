using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarSpecificationService : ICarSpecificationService
    {
        private readonly ICarSpecificationRepository _carSpecificationRepository;

        public CarSpecificationService(ICarSpecificationRepository carSpecificationRepository)
        {
            _carSpecificationRepository = carSpecificationRepository;
        }

        public async Task<RequestResult<CarSpecification>> GetCarSpecificationById(int id)
        {
            var carSpecification = await _carSpecificationRepository.GetByIdAsync(id);
            if (carSpecification is null)
            {
                return RequestResult<CarSpecification>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<CarSpecification>.Success(carSpecification);
        }

        public async Task<RequestResult<IEnumerable<CarSpecification>>> GetCarSpecifications()
        {
            var carSpecifications = await _carSpecificationRepository.GetAllAsync();
            if (carSpecifications is null)
            {
                return RequestResult<IEnumerable<CarSpecification>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CarSpecification>>.Success(carSpecifications);

        }


    }
}
