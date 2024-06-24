using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IFuelTypeService
    {
        public Task<RequestResult<IEnumerable<FuelTypeDto>>> GetFuelTypeDtos();
    }
}
