using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Listings
{
    public class IdentifiedVehiclesService : IIdentifiedVehiclesService
    {
        private readonly IIdentifiedVehiclesRepository _identifiedVehiclesRepository;

        public IdentifiedVehiclesService(IIdentifiedVehiclesRepository identifiedVehiclesRepository)
        {
            _identifiedVehiclesRepository = identifiedVehiclesRepository;
        }

        public async Task<RequestResult> AddIdentifiedVehicle(IdentifiedVehicles identifiedVehicle)
        {
            await _identifiedVehiclesRepository.Add(identifiedVehicle);
            await _identifiedVehiclesRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteIdentifiedVehicle(int id)
        {
            var result = await _identifiedVehiclesRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _identifiedVehiclesRepository.Delete(result);
            await _identifiedVehiclesRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult<IdentifiedVehicles>> GetIdentifiedVehicleId(int id)
        {
            var result = await _identifiedVehiclesRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult<IdentifiedVehicles>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IdentifiedVehicles>.Success(result);
        }

        public async Task<RequestResult<IEnumerable<IdentifiedVehicles>>> GetIdentifiedVehicles()
        {
            var result = await _identifiedVehiclesRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<IdentifiedVehicles>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<IdentifiedVehicles>>.Success(result);
        }
    }
}
