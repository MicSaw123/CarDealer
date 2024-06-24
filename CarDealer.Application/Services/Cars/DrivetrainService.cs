using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class DrivetrainService : IDrivetrainService
    {
        private readonly IDrivetrainRepository _drivetrainRepository;
        private readonly IMapper _mapper;

        public DrivetrainService(IDrivetrainRepository drivetrainRepository, IMapper mapper)
        {
            _drivetrainRepository = drivetrainRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<DrivetrainDto>>> GetDrivetrains()
        {
            var drivetrains = await _drivetrainRepository.GetAllAsync();
            IEnumerable<DrivetrainDto> drivetrainDtos = _mapper.Map<IEnumerable<DrivetrainDto>>(drivetrains);
            if (drivetrainDtos is null)
            {
                return RequestResult<IEnumerable<DrivetrainDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<DrivetrainDto>>.Success(drivetrainDtos);
        }
    }
}
