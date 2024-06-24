using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;
using System.Linq.Expressions;

namespace CarDealer.Application.Services.Listings
{
    public class IdentifiedVehiclesService : IIdentifiedVehiclesService
    {
        private readonly IIdentifiedVehiclesRepository _identifiedVehiclesRepository;
        private readonly IMapper _mapper;

        public IdentifiedVehiclesService(IIdentifiedVehiclesRepository identifiedVehiclesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _identifiedVehiclesRepository = identifiedVehiclesRepository;
        }

        public async Task<RequestResult> AddIdentifiedVehicle(AddIdentifiedVehiclesDto identifiedVehicle)
        {
            var identifiedVehicleDto = _mapper.Map<IdentifiedVehicles>(identifiedVehicle);
            if (identifiedVehicleDto is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _identifiedVehiclesRepository.Add(identifiedVehicleDto);
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

        public async Task<RequestResult<GetIdentifiedVehiclesDto>> GetIdentifiedVehicleId(int id)
        {
            var includes = new List<Expression<Func<IdentifiedVehicles, object>>>();
            includes.Add(x => x.CountryOfOrigin);
            includes.Add(x => x.PreviouslyDamaged);
            var identifiedVehicle = await _identifiedVehiclesRepository.GetByIdAsync(id, includes);
            var identifiedVehicleDto = _mapper.Map<GetIdentifiedVehiclesDto>(identifiedVehicle);
            if (identifiedVehicleDto is null)
            {
                return RequestResult<GetIdentifiedVehiclesDto>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<GetIdentifiedVehiclesDto>.Success(identifiedVehicleDto);
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
