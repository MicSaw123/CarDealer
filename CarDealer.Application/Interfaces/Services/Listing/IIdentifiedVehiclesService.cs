using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IIdentifiedVehiclesService
    {
        Task<RequestResult<IEnumerable<IdentifiedVehicles>>> GetIdentifiedVehicles();

        Task<RequestResult<IdentifiedVehicles>> GetIdentifiedVehicleId(int id);

        Task<RequestResult> AddIdentifiedVehicle(IdentifiedVehicles identifiedVehicle);

        Task<RequestResult> DeleteIdentifiedVehicle(int id);
    }
}
