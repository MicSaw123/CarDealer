using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IIdentifiedVehiclesService
    {
        Task<RequestResult<GetIdentifiedVehiclesDto>> GetIdentifiedVehicleId(int id);

        Task<RequestResult> AddIdentifiedVehicle(AddIdentifiedVehiclesDto identifiedVehicle);

        Task<RequestResult> DeleteIdentifiedVehicle(int id);
    }
}
