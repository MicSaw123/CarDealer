using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IManufacturerService
    {
        public Task<RequestResult<Manufacturer>> GetManufacturerById(int manufacturerId);

        public Task<RequestResult<IEnumerable<Manufacturer>>> GetManufacturers();
    }
}
