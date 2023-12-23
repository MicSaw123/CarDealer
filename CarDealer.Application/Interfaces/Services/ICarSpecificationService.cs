using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface ICarSpecificationService
    {
        Task<IEnumerable<CarSpecification>> GetCarSpecifications();

        Task<CarSpecification> GetCarSpecificationById(int id);
    }
}
