using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IGenerationService
    {
        public Task<RequestResult<IEnumerable<GenerationDto>>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default);

    }
}
