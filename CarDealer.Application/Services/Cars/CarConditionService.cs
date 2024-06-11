using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class CarConditionService : ICarConditionService
    {
        private readonly ICarConditionRepository _carConditionRepository;

        public CarConditionService(ICarConditionRepository carConditionRepository)
        {
            _carConditionRepository = carConditionRepository;
        }
        public async Task<RequestResult<IEnumerable<CarCondition>>> GetCarConditions()
        {
            var result = await _carConditionRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<CarCondition>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<CarCondition>>.Success(result);
        }
    }
}
