using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ITransmissionService
    {
        public Task<RequestResult<Transmission>> GetTransmissionById(int transmissionId);

        public Task<RequestResult<IEnumerable<Transmission>>> GetTransmissions();
    }
}
