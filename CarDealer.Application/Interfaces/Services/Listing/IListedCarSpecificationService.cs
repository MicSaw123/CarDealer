using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListedCarSpecificationService
    {
        Task<RequestResult<GetListedCarSpecificationsDto>> GetListedCarSpecificationById(int id);

        Task<RequestResult> AddListedCarSpecification(AddListedCarSpecificationDto listedCarSpecification);

        Task<RequestResult> DeleteListedCarSpecification(int id);
    }
}
