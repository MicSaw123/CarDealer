using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface IModelService
    {
        public Task<Model> GetModelById(int modelId);

        public Task<IEnumerable<Model>> GetModels();

        public Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default);
    }
}
