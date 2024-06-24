using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<ModelDto>>> GetModelDtosByManufacturerId(int manufacturerId, CancellationToken cancellationToken = default)
        {
            var modelsByManufacturer = await _modelRepository.GetModelsByManufacturerIdAsync(manufacturerId, cancellationToken);
            IEnumerable<ModelDto> modelDtos = _mapper.Map<IEnumerable<ModelDto>>(modelsByManufacturer);
            if (modelDtos is null)
            {
                return RequestResult<IEnumerable<ModelDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<ModelDto>>.Success(modelDtos);
        }
    }
}
