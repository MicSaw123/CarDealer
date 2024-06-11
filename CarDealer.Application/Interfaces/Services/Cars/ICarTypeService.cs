using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarTypeService
    {
        Task<RequestResult<IEnumerable<CarType>>> GetCarTypes();

        Task<RequestResult<CarType>> GetCarTypeById(int id);

        Task<RequestResult> Add(CarType carType);

        Task<RequestResult> DeleteCarType(int id);
    }
}
