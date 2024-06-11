using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarColorService
    {
        public Task<RequestResult<CarColor>> GetCarColorById(int carColorId);

        public Task<RequestResult<IEnumerable<CarColor>>> GetCarColors();
    }
}
