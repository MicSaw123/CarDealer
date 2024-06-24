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
    public class ListedCarService : IListedCarService
    {
        private readonly IListedCarRepository _listedCarRepository;
        private readonly IMapper _mapper;
        private readonly IListedCarSpecificationService _listedCarSpecificationService;

        public ListedCarService(IListedCarRepository listedCarRepository, IMapper mapper,
             IListedCarSpecificationService listedCarSpecificationService)
        {
            _listedCarRepository = listedCarRepository;
            _mapper = mapper;
            _listedCarSpecificationService = listedCarSpecificationService;
        }

        public async Task<RequestResult> AddListedCar(AddListedCarDto listedCar)
        {
            var listedCarDto = _mapper.Map<ListedCar>(listedCar);
            if (listedCarDto is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _listedCarRepository.Add(listedCarDto);
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

        public async Task<RequestResult<GetListedCarsDto>> GetListedCarById(int id)
        {
            var includes = new List<Expression<Func<ListedCar, object>>>();
            includes.Add(x => x.CarColor);
            includes.Add(x => x.CarCondition);
            includes.Add(x => x.ListedCarSpecification);
            var listedCar = await _listedCarRepository.GetByIdAsync(id, includes);
            var listedCarDto = _mapper.Map<GetListedCarsDto>(listedCar);
            var listedCarSpecification = await _listedCarSpecificationService.GetListedCarSpecificationById(listedCarDto.ListedCarSpecificationId);
            listedCarDto.ListedCarSpecification = listedCarSpecification.Result;
            if (listedCarDto is null)
            {
                return RequestResult<GetListedCarsDto>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<GetListedCarsDto>.Success(listedCarDto);
        }
    }
}
