using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface ITransmissionService
    {
        public Task<Transmission> GetTransmissionById(int transmissionId);

        public Task<IEnumerable<Transmission>> GetTransmissions();
    }
}
