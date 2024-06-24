using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarConditionService
    {
        public Task<RequestResult<IEnumerable<CarConditionDto>>> GetCarConditions();

    }
}
