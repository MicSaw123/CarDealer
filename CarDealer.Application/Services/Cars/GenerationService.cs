using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class GenerationService : IGenerationService
    {
        private readonly IGenerationRepository _generationRepository;
        private readonly IMapper _mapper;

        public GenerationService(IGenerationRepository generationRepository, IMapper mapper)
        {
            _generationRepository = generationRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<GenerationDto>>> GetGenerationsByModelIdAsync(int modelId, CancellationToken cancellationToken = default)
        {
            var generationsByModelId = await _generationRepository.GetGenerationByModelIdAsync(modelId, cancellationToken);
            IEnumerable<GenerationDto> generationDtos = _mapper.Map<IEnumerable<GenerationDto>>(generationsByModelId);
            if (generationsByModelId is null)
            {
                return RequestResult<IEnumerable<GenerationDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<GenerationDto>>.Success(generationDtos);
        }
    }
}
