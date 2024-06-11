using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class DoorQuantityService : IDoorQuantityService
    {
        private readonly IDoorQuantityRepository _doorQuantityRepository;

        public DoorQuantityService(IDoorQuantityRepository doorQuantityRepository)
        {
            _doorQuantityRepository = doorQuantityRepository;
        }

        public async Task<RequestResult<IEnumerable<DoorQuantity>>> GetDoorQuantities()
        {
            var result = await _doorQuantityRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<DoorQuantity>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<DoorQuantity>>.Success(result);
        }

        public async Task<RequestResult<DoorQuantity>> GetDoorQuantityById(int manufacturerId)
        {
            var result = await _doorQuantityRepository.GetByIdAsync(manufacturerId);
            if (result is null)
            {
                return RequestResult<DoorQuantity>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<DoorQuantity>.Success(result);
        }
    }
}
