using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IEngineService
    {
        Task<RequestResult<IEnumerable<Engine>>> GetEngines();

        public Task<RequestResult<Engine>> GetEngineById(int engineId);
    }
}
