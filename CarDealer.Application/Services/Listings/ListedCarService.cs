using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Listings
{
    public class ListedCarService : IListedCarService
    {
        private readonly IListedCarRepository _listedCarRepository;

        public ListedCarService(IListedCarRepository listedCarRepository)
        {
            _listedCarRepository = listedCarRepository;
        }

        public async Task<RequestResult> AddListedCar(ListedCar listedCar)
        {
            await _listedCarRepository.Add(listedCar);
            await _listedCarRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteListedCar(int id)
        {
            var result = await _listedCarRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _listedCarRepository.Delete(result);
            await _listedCarRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult<ListedCar>> GetListedCarById(int id)
        {
            var result = await _listedCarRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult<ListedCar>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<ListedCar>.Success(result);
        }

        public async Task<RequestResult<IEnumerable<ListedCar>>> GetListedCars()
        {
            var result = await _listedCarRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<ListedCar>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<ListedCar>>.Success(result);
        }
    }
}
