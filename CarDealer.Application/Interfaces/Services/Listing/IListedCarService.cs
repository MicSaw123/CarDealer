using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IListedCarService
    {
        Task<RequestResult<IEnumerable<ListedCar>>> GetListedCars();

        Task<RequestResult<ListedCar>> GetListedCarById(int id);

        Task<RequestResult> AddListedCar(ListedCar listedCar);

        Task<RequestResult> DeleteListedCar(int id);
    }
}
