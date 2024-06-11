using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IDoorQuantityService
    {
        public Task<RequestResult<DoorQuantity>> GetDoorQuantityById(int doorQuantityId);

        public Task<RequestResult<IEnumerable<DoorQuantity>>> GetDoorQuantities();
    }
}
