using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface ICarTypeService
    {
        Task<IEnumerable<CarType>> GetCarTypes();

        Task<CarType> GetCarTypeById(int id);
    }
}
