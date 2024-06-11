using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IPreviouslyDamagedService
    {
        public Task<RequestResult<IEnumerable<PreviouslyDamaged>>> GetPreviouslyDamaged();
    }
}
