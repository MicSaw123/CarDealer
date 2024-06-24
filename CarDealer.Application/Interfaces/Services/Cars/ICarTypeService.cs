using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarTypeService
    {
        Task<RequestResult<IEnumerable<CarTypeDto>>> GetCarTypes();
    }
}
