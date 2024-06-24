using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarColorService
    {
        public Task<RequestResult<IEnumerable<CarColorDto>>> GetCarColors();
    }
}
