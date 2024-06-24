using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IDoorQuantityService
    {
        public Task<RequestResult<IEnumerable<DoorQuantityDto>>> GetDoorQuantities();
    }
}
