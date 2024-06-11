using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListedCarSpecificationService
    {
        Task<RequestResult<IEnumerable<ListedCarSpecification>>> GetListedCarSpecifications();

        Task<RequestResult<ListedCarSpecification>> GetListedCarSpecificationById(int id);

        Task<RequestResult> AddListedCarSpecification(ListedCarSpecification listedCarSpecification);

        Task<RequestResult> DeleteListedCarSpecification(int id);
    }
}
