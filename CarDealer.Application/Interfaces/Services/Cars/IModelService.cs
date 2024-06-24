using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IModelService
    {
        public Task<RequestResult<IEnumerable<ModelDto>>> GetModelDtosByManufacturerId(int manufacturerId, CancellationToken cancellationToken = default);

    }
}
