using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IModelService
    {
        public Task<RequestResult<Model>> GetModelById(int modelId);

        public Task<RequestResult<IEnumerable<Model>>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default);
    }
}
