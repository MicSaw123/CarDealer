using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task<RequestResult<Manufacturer>> GetManufacturerById(int manufacturerId)
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(manufacturerId);
            if (manufacturer is null)
            {
                return RequestResult<Manufacturer>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Manufacturer>.Success(manufacturer);
        }

        public async Task<RequestResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            if (manufacturers is null)
            {
                return RequestResult<IEnumerable<Manufacturer>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Manufacturer>>.Success(manufacturers);
        }
    }
}
