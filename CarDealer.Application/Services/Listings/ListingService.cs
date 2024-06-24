using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;
using System.Linq.Expressions;

namespace CarDealer.Application.Services.Listings
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly IListedCarService _listedCarService;
        private readonly IListedCarSpecificationService _listedCarSpecificationService;
        private readonly IIdentifiedVehiclesService _identifiedVehiclesService;
        private readonly IDbContext _context;
        private readonly IIdentifiedVehiclesRepository _identifiedVehiclesRepository;
        private readonly IListedCarRepository _listedCarRepository;
        private readonly IListedCarSpecificationRepository _listedCarSpecificationRepository;

        public ListingService(IListingRepository listingRepository, IImageService imageService, IMapper mapper,
            IListedCarService listedCarService, IListedCarSpecificationService listedCarSpecificationService,
            IIdentifiedVehiclesService identifiedVehiclesService, IDbContext context,
            IIdentifiedVehiclesRepository identifiedVehiclesRepository,
            IListedCarRepository listedCarRepository, IListedCarSpecificationRepository listedCarSpecificationRepository)
        {
            _listingRepository = listingRepository;
            _imageService = imageService;
            _mapper = mapper;
            _listedCarService = listedCarService;
            _listedCarSpecificationService = listedCarSpecificationService;
            _identifiedVehiclesService = identifiedVehiclesService;
            _context = context;
            _identifiedVehiclesRepository = identifiedVehiclesRepository;
            _listedCarRepository = listedCarRepository;
            _listedCarSpecificationRepository = listedCarSpecificationRepository;
        }

        public async Task<RequestResult<IEnumerable<GetListingsDto>>> GetAllListings()
        {
            var includes = new List<Expression<Func<Listing, object>>>();
            includes.Add(x => x.IdentifiedVehicles.CountryOfOrigin);
            includes.Add(x => x.ListedCar.CarCondition);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Transmission);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Engine.FuelType);
            var listings = await _listingRepository.GetAllAsync(includes);
            IEnumerable<GetListingsDto> listingDtos = _mapper.Map<IEnumerable<GetListingsDto>>(listings);
            foreach (var listing in listingDtos)
            {
                var images = await _imageService.DownloadImagesFromFTP(listing.Title + "_" + listing.Id);
                listing.Images = images.Result;
            }
            if (listingDtos is null)
            {
                return RequestResult<IEnumerable<GetListingsDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<GetListingsDto>>.Success(listingDtos);
        }

        public async Task<RequestResult> AddListing(AddListingDto listingDto)
        {
            var listing = _mapper.Map<Listing>(listingDto);
            await _listingRepository.Add(listing);
            var result = await _listingRepository.SaveChangesAsync();
            if (!result)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _imageService.UploadImageToFTP(listingDto.Images, listingDto.Title + "_" + listing.Id);
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteListing(int id)
        {
            var result = await _listingRepository.GetByIdAsync(id);
            var identifiedVehicle = await _identifiedVehiclesRepository.GetByIdAsync(result.IdentifiedVehiclesId);
            var listedCar = await _listedCarRepository.GetByIdAsync(result.ListedCarId);
            var listedCarSpecification = await _listedCarSpecificationRepository.
                GetByIdAsync(result.ListedCar.ListedCarSpecificationId);
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _identifiedVehiclesRepository.Delete(identifiedVehicle);
            await _listedCarSpecificationRepository.Delete(listedCarSpecification);
            await _listedCarRepository.Delete(listedCar);
            await _listingRepository.Delete(result);
            await _listingRepository.SaveChangesAsync();
            return RequestResult.Success();
        }

        public async Task<RequestResult<GetListingsDto>> GetListingById(int id)
        {
            var includes = new List<Expression<Func<Listing, object>>>();
            includes.Add(x => x.ListedCar.ListedCarSpecification);
            var listing = await _listingRepository.GetByIdAsync(id, includes);

            var images = await _imageService.DownloadImagesFromFTP(listing.Title + "_" + listing.Id);
            GetListingsDto getListingsDto = _mapper.Map<GetListingsDto>(listing);
            getListingsDto.Images = images.Result;
            if (getListingsDto is null)
            {
                return RequestResult<GetListingsDto>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<GetListingsDto>.Success(getListingsDto);
        }

        public async Task<RequestResult<List<GetListingsDto>>> GetListingsBySellerId(int id)
        {
            List<Listing> listings = new List<Listing>();
            _context.Set<Listing>().Where(l => l.SellerId == id).ToList().ForEach(listings.Add);
            var getListingDtos = _mapper.Map<List<GetListingsDto>>(listings);
            foreach (var listingDtos in getListingDtos)
            {
                var identifiedVehicle = await _identifiedVehiclesService.GetIdentifiedVehicleId(listingDtos.IdentifiedVehiclesId);
                var listedCar = await _listedCarService.GetListedCarById(listingDtos.ListedCarId);
                listingDtos.IdentifiedVehicles = identifiedVehicle.Result;
                listingDtos.ListedCar = listedCar.Result;
                var images = await _imageService.DownloadImagesFromFTP(listingDtos.Title + "_" + listingDtos.Id);
                listingDtos.Images = images.Result;
            }
            if (getListingDtos is null)
            {
                return RequestResult<List<GetListingsDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<List<GetListingsDto>>.Success(getListingDtos);
        }

        public async Task<RequestResult> UpdateListing(AddListingDto addListingsDto)
        {
            var result = _mapper.Map<Listing>(addListingsDto);
            if (addListingsDto is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            _listingRepository.Update(result);
            await _listingRepository.SaveChangesAsync();
            return RequestResult.Success();
        }
    }
}
