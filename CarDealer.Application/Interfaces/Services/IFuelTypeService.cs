using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface IFuelType
    {
        public Task<FuelType> GetFuelTypeById(int fuelTypeId);

        public Task<IEnumerable<FuelType>> GetFuelTypes();
    }
}
