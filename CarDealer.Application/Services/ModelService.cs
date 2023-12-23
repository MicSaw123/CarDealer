using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public async Task<Model> GetModelById(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            return model;
        }

        public async Task<IEnumerable<Model>> GetModels()
        {
            return await _modelRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Model>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default)
        {
            return await _modelRepository.GetModelsByManufacturerIdAsync(manufacturerId, cancellationToken);
        }
    }
}
