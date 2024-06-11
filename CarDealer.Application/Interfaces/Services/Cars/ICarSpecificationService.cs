using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarSpecificationService
    {
        Task<RequestResult<IEnumerable<CarSpecification>>> GetCarSpecifications();

        Task<RequestResult<CarSpecification>> GetCarSpecificationById(int id);
    }
}
