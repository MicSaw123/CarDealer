using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarConditionService
    {
        public Task<RequestResult<IEnumerable<CarCondition>>> GetCarConditions();

    }
}
