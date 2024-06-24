using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IEngineService
    {
        Task<RequestResult<IEnumerable<EngineDto>>> GetEngines();

        public Task<RequestResult<Engine>> GetEngineById(int engineId);
    }
}
