using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ITransmissionRepository _transmissionRepository;

        public TransmissionService(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }

        public async Task<Transmission> GetTransmissionById(int transmissionId)
        {
            var transmission = await _transmissionRepository.GetByIdAsync(transmissionId);
            return transmission;
        }

        public async Task<IEnumerable<Transmission>> GetTransmissions()
        {
            return await _transmissionRepository.GetAllAsync();
        }
    }
}
