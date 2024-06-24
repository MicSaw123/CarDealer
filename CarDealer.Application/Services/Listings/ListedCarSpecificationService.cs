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
    internal class ListedCarSpecificationService : IListedCarSpecificationService
    {
        private readonly IListedCarSpecificationRepository _listedCarSpecificationRepository;
        private readonly IMapper _mapper;

        public ListedCarSpecificationService(IListedCarSpecificationRepository listedCarSpecificationRepository, IMapper mapper)
        {
            _listedCarSpecificationRepository = listedCarSpecificationRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> AddListedCarSpecification(AddListedCarSpecificationDto listedCarSpecification)
        {
            var listedCarSpecificationDto = _mapper.Map<ListedCarSpecification>(listedCarSpecification);
            await _listedCarSpecificationRepository.Add(listedCarSpecificationDto);
            if (listedCarSpecificationDto is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
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

        public async Task<RequestResult<GetListedCarSpecificationsDto>> GetListedCarSpecificationById(int id)
        {
            var includes = new List<Expression<Func<ListedCarSpecification, object>>>();
            includes.Add(x => x.CarType);
            includes.Add(x => x.DoorQuantity);
            includes.Add(x => x.Drivetrain);
            includes.Add(x => x.Transmission);
            includes.Add(x => x.Engine.FuelType);
            includes.Add(x => x.Generation.Model.Manufacturer);
            var result = await _listedCarSpecificationRepository.GetByIdAsync(id, includes);
            var ls = _mapper.Map<GetListedCarSpecificationsDto>(result);
            if (ls is null)
            {
                return RequestResult<GetListedCarSpecificationsDto>.Failure(Error.ErrorUnknown);
            }

            return RequestResult<GetListedCarSpecificationsDto>.Success(ls);
        }
    }
}
