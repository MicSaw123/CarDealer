using CarDealer.Application.Interfaces.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Repositories.Cars
{
    public interface ICarSpecificationRepository : IGenericRepository<CarSpecification>
    {
    }
}
