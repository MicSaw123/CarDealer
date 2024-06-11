using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public async Task<RequestResult<Model>> GetModelById(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            if (model is null)
            {
                return RequestResult<Model>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Model>.Success(model);
        }

        public async Task<RequestResult<IEnumerable<Model>>> GetModelsByManufacturerIdAsync(int manufacturerId, CancellationToken cancellationToken = default)
        {
            var modelsByManufacturer = await _modelRepository.GetModelsByManufacturerIdAsync(manufacturerId, cancellationToken);
            if (modelsByManufacturer is null)
            {
                return RequestResult<IEnumerable<Model>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Model>>.Success(modelsByManufacturer);
        }
    }
}
