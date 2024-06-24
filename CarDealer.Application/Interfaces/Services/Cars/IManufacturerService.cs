using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IManufacturerService
    {
        public Task<RequestResult<IEnumerable<ManufacturerDto>>> GetManufacturerDtos();
    }
}
