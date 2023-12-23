using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task<Manufacturer> GetManufacturerById(int manufacturerId)
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(manufacturerId);
            return manufacturer;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            return await _manufacturerRepository.GetAllAsync();
        }
    }
}
