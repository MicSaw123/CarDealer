using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ITransmissionRepository _transmissionRepository;

        public TransmissionService(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }

        public async Task<RequestResult<Transmission>> GetTransmissionById(int transmissionId)
        {
            var transmission = await _transmissionRepository.GetByIdAsync(transmissionId);
            if (transmission is null)
            {
                return RequestResult<Transmission>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Transmission>.Success(transmission);
        }

        public async Task<RequestResult<IEnumerable<Transmission>>> GetTransmissions()
        {
            var transmissions = await _transmissionRepository.GetAllAsync();
            if (transmissions is null)
            {
                return RequestResult<IEnumerable<Transmission>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Transmission>>.Success(transmissions);
        }
    }
}
