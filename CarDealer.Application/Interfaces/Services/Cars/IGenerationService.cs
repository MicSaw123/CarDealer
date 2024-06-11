using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IGenerationService
    {
        public Task<RequestResult<Generation>> GetGenerationById(int generationId);


        public Task<RequestResult<IEnumerable<Generation>>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default);

    }
}
