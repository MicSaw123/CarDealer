using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ITransmissionService
    {
        public Task<RequestResult<IEnumerable<TransmissionDto>>> GetTransmissions();
    }
}
