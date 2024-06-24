using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public TransmissionService(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<TransmissionDto>>> GetTransmissions()
        {
            var transmissions = await _transmissionRepository.GetAllAsync();
            IEnumerable<TransmissionDto> transmissionDtos = _mapper.Map<IEnumerable<TransmissionDto>>(transmissions);
            if (transmissionDtos is null)
            {
                return RequestResult<IEnumerable<TransmissionDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<TransmissionDto>>.Success(transmissionDtos);
        }
    }
}
