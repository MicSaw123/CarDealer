using CarDealer.Domain.Entities;

namespace CarDealer.Application.Interfaces.Services
{
    public interface IEngineService
    {
        Task<IEnumerable<Engine>> GetEngines();

        public Task<Engine> GetEngineById(int engineId);
    }
}
