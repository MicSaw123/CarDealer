using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IPreviouslyDamagedService
    {
        public Task<RequestResult<IEnumerable<PreviouslyDamagedDto>>> GetPreviouslyDamaged();
    }
}
