using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface IManufacturerService
    {
        public Task<Manufacturer> GetManufacturerById(int manufacturerId);

        public Task<IEnumerable<Manufacturer>> GetManufacturers();
    }
}
