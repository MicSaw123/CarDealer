using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListedCarService
    {
        Task<RequestResult<GetListedCarsDto>> GetListedCarById(int id);

        Task<RequestResult> AddListedCar(AddListedCarDto listedCar);

        Task<RequestResult> DeleteListedCar(int id);
    }
}
