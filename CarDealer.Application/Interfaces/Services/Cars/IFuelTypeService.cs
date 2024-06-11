using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IFuelType
    {
        public Task<FuelType> GetFuelTypeById(int fuelTypeId);

        public Task<RequestResult<IEnumerable<FuelType>>> GetFuelTypes();
    }
}
