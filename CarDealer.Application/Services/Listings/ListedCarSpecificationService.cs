using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Listings
{
    internal class ListedCarSpecificationService : IListedCarSpecificationService
    {
        private readonly IListedCarSpecificationRepository _listedCarSpecificationRepository;

        public ListedCarSpecificationService(IListedCarSpecificationRepository listedCarSpecificationRepository)
        {
            _listedCarSpecificationRepository = listedCarSpecificationRepository;
        }

        public async Task<RequestResult> AddListedCarSpecification(ListedCarSpecification listedCarSpecification)
        {
            await _listedCarSpecificationRepository.Add(listedCarSpecification);
            await _listedCarSpecificationRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteListedCarSpecification(int id)
        {
            var result = await _listedCarSpecificationRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _listedCarSpecificationRepository.Delete(result);
            await _listedCarSpecificationRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult<ListedCarSpecification>> GetListedCarSpecificationById(int id)
        {
            var result = await _listedCarSpecificationRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult<ListedCarSpecification>.Failure(Error.ErrorUnknown);
            }

            return RequestResult<ListedCarSpecification>.Success(result);
        }

        public async Task<RequestResult<IEnumerable<ListedCarSpecification>>> GetListedCarSpecifications()
        {
            var result = await _listedCarSpecificationRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<ListedCarSpecification>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<ListedCarSpecification>>.Success(result);
        }
    }
}
