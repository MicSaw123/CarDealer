using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class GenerationService : IGenerationService
    {
        private readonly IGenerationRepository _generationRepository;

        public GenerationService(IGenerationRepository generationRepository)
        {
            _generationRepository = generationRepository;
        }
        public async Task<RequestResult<Generation>> GetGenerationById(int generationId)
        {
            var generation = await _generationRepository.GetByIdAsync(generationId);
            if (generation == null)
            {
                return RequestResult<Generation>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Generation>.Success(generation);
        }

        public async Task<RequestResult<IEnumerable<Generation>>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default)
        {
            var generationsByModelId = await _generationRepository.GetGenerationByModelIdAsync(modelId, cancellationToken);
            if (generationsByModelId is null)
            {
                return RequestResult<IEnumerable<Generation>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Generation>>.Success(generationsByModelId);
        }
    }
}
