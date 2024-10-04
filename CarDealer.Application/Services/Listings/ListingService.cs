using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.SearchListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto;
using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace CarDealer.Application.Services.Listings
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly IListedCarService _listedCarService;
        private readonly IIdentifiedVehiclesService _identifiedVehiclesService;
        private readonly IDbContext _context;
        private readonly IIdentifiedVehiclesRepository _identifiedVehiclesRepository;
        private readonly IListedCarRepository _listedCarRepository;
        private readonly IListedCarSpecificationRepository _listedCarSpecificationRepository;
        string host = "ftp://192.168.1.33/";
        string userName = "Anonymous";
        string password = "mic_saw123@o2.pl";

        public ListingService(IListingRepository listingRepository, IImageService imageService, IMapper mapper,
            IListedCarService listedCarService, IIdentifiedVehiclesService identifiedVehiclesService, IDbContext context,
            IIdentifiedVehiclesRepository identifiedVehiclesRepository, IListedCarRepository listedCarRepository,
            IListedCarSpecificationRepository listedCarSpecificationRepository)
        {
            _listingRepository = listingRepository;
            _imageService = imageService;
            _mapper = mapper;
            _listedCarService = listedCarService;
            _identifiedVehiclesService = identifiedVehiclesService;
            _context = context;
            _identifiedVehiclesRepository = identifiedVehiclesRepository;
            _listedCarRepository = listedCarRepository;
            _listedCarSpecificationRepository = listedCarSpecificationRepository;
        }

        public async Task<RequestResult> AddListing(AddListingDto listingDto)
        {
            List<IFormFile> images = new List<IFormFile>();
            int i = 0;
            var listing = _mapper.Map<Listing>(listingDto);
            listing.IsActive = true;
            listing.DateOfCreation = DateTime.Now;
            await _listingRepository.Add(listing);
            foreach (var byteArray in listingDto.Images)
            {
                i++;
                var stream = new MemoryStream(byteArray);
                IFormFile image = new FormFile(stream, 0, byteArray.Length, "1", i + ".jpg");
                images.Add(image);
            }
            var result = await _listingRepository.SaveChangesAsync();
            if (!result)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _imageService.UploadImageToFTP(images, listingDto.Title + "_" + listing.Id);
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateListing(UpdateListingDto updateListingsDto, string path)
        {
            var result = _mapper.Map<Listing>(updateListingsDto);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + path);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = result.Title + "_" + result.Id;
            request.Credentials = new NetworkCredential(userName, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            _listingRepository.Update(result);
            await _listingRepository.SaveChangesAsync();
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
            await _listedCarSpecificationRepository.Delete(listedCarSpecification);
            await _listedCarRepository.Delete(listedCar);
            await _identifiedVehiclesRepository.Delete(identifiedVehicle);
            await _listingRepository.Delete(result);
            await _listingRepository.SaveChangesAsync();

            await _imageService.DeleteListingFolder(result.Title + "_" + result.Id);
            return RequestResult.Success();
        }

        public async Task<RequestResult<GetListingsDto>> GetListingById(int id)
        {
            var includes = new List<Expression<Func<Listing, object>>>();
            includes.Add(x => x.ListedCar.ListedCarSpecification.CarType);
            includes.Add(x => x.ListedCar.ListedCarSpecification.DoorQuantity);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Generation);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Generation.Model);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Generation.Model.Manufacturer);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Engine);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Engine.FuelType);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Transmission);
            includes.Add(x => x.ListedCar.ListedCarSpecification.Drivetrain);
            includes.Add(x => x.IdentifiedVehicles.CountryOfOrigin);
            includes.Add(x => x.IdentifiedVehicles.PreviouslyDamaged);
            includes.Add(x => x.ListedCar.CarColor);
            includes.Add(x => x.ListedCar.CarCondition);
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

        public async Task<RequestResult<IEnumerable<GetListingsDto>>>
            FilterListings(int sortingId, ListingsSearchConditions listingsSearchConditions)
        {
            var listingsToSort = _context.Set<Listing>().
                Include(x => x.IdentifiedVehicles.PreviouslyDamaged).
                Include(x => x.IdentifiedVehicles.CountryOfOrigin).Include(x => x.ListedCar.CarCondition).
                Include(x => x.ListedCar.CarColor).
                Include(x => x.ListedCar.ListedCarSpecification.Transmission).
                Include(x => x.ListedCar.ListedCarSpecification.Engine.FuelType).
                Where(x => x.IsActive);
            if (listingsSearchConditions.DrivetrainId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Drivetrain.Id ==
                listingsSearchConditions.DrivetrainId);
            }
            if (listingsSearchConditions.CountryOfOriginId != 0)
            {
                listingsToSort = listingsToSort.Where(x => x.IdentifiedVehicles.CountryOfOriginId ==
                listingsSearchConditions.CountryOfOriginId);
            }
            if (listingsSearchConditions.GenerationId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.GenerationId ==
                listingsSearchConditions.GenerationId);
            }
            if (listingsSearchConditions.ModelId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Generation.ModelId == listingsSearchConditions.ModelId);
            }
            if (listingsSearchConditions.ManufacturerId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Generation.Model.ManufacturerId ==
                listingsSearchConditions.ManufacturerId);
            }
            if (listingsSearchConditions.TransmissionId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.TransmissionId ==
                listingsSearchConditions.TransmissionId);
            }
            if (listingsSearchConditions.CarTypeId != 0)
            {
                listingsToSort = listingsToSort.Where(x => x.ListedCar.ListedCarSpecification.CarTypeId ==
                listingsSearchConditions.CarTypeId);
            }
            if (listingsSearchConditions.CarColorId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.CarColorId == listingsSearchConditions.CarColorId);
            }
            if (listingsSearchConditions.CarConditionId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.CarConditionId == listingsSearchConditions.CarConditionId);
            }
            if (listingsSearchConditions.DoorQuantityId != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.CarConditionId == listingsSearchConditions.CarConditionId);
            }
            if (listingsSearchConditions.MinHorsepower != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Engine.Horsepower
                >= listingsSearchConditions.MinHorsepower);
            }
            if (listingsSearchConditions.MaxHorsepower != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Engine.Horsepower
                <= listingsSearchConditions.MaxHorsepower);
            }
            if (listingsSearchConditions.MinMileage != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.Mileage > listingsSearchConditions.MinMileage);
            }
            if (listingsSearchConditions.MaxMileage != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.Mileage <= listingsSearchConditions.MaxMileage);
            }
            if (listingsSearchConditions.MinDisplacement != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Engine.Displacement
                >= listingsSearchConditions.MinDisplacement);
            }
            if (listingsSearchConditions.MaxDisplacement != 0)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.ListedCar.ListedCarSpecification.Engine.Displacement
                <= listingsSearchConditions.MaxDisplacement);
            }
            if (listingsSearchConditions.MinPrice != 0)
            {
                listingsToSort = listingsToSort.Where(x => x.Price >= listingsSearchConditions.MinPrice);
            }
            if (listingsSearchConditions.MaxPrice != 0)
            {
                listingsToSort = listingsToSort.Where(x => x.Price <= listingsSearchConditions.MaxPrice);
            }
            if (listingsSearchConditions.KeyWords != null)
            {
                listingsToSort = listingsToSort.Where(x =>
                x.Description.Contains(listingsSearchConditions.KeyWords) ||
                x.Title.Contains(listingsSearchConditions.KeyWords));
            }
            SortingMethods sortingMethod = (SortingMethods)sortingId;
            listingsToSort = listingsToSort.SortListings(sortingMethod);
            var sortedListings = _mapper.Map<IEnumerable<GetListingsDto>>(listingsToSort);
            foreach (var listing in sortedListings)
            {
                var images = await _imageService.DownloadImagesFromFTP(listing.Title + "_" + listing.Id);
                listing.Images = images.Result;
            }
            return RequestResult<IEnumerable<GetListingsDto>>.Success(sortedListings);
        }
        public async Task<RequestResult<IEnumerable<GetListingsDto>>> GetActiveListings()
        {
            var listings = _context.Set<Listing>().Where(x => x.IsActive == true).
                Include(x => x.IdentifiedVehicles.PreviouslyDamaged).
                Include(x => x.IdentifiedVehicles.CountryOfOrigin).
                Include(x => x.ListedCar.CarCondition).
                Include(x => x.ListedCar.CarColor).
                Include(x => x.ListedCar.ListedCarSpecification.Transmission).
                Include(x => x.ListedCar.ListedCarSpecification.Engine.FuelType);
            var listingDtos = _mapper.Map<IEnumerable<GetListingsDto>>(listings);
            foreach (var listing in listingDtos)
            {
                var images = await _imageService.DownloadImagesFromFTP(listing.Title + "_" + listing.Id);
                listing.Images = images.Result;
            }
            if (listings is null)
            {
                return RequestResult<IEnumerable<GetListingsDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<GetListingsDto>>.Success(listingDtos);
        }

        public async Task<RequestResult<IEnumerable<GetListingsDto>>> DeactivateOldListings()
        {
            var entities = _context.Set<Listing>().Where(x => x.IsActive == true);
            foreach (var entity in entities)
            {
                if ((entity.DateOfCreation - DateTime.Now).TotalDays > 10)
                {
                    entity.IsActive = false;
                }
            }
            await _listingRepository.SaveChangesAsync();
            var listings = _mapper.Map<IEnumerable<GetListingsDto>>(entities);
            return RequestResult<IEnumerable<GetListingsDto>>.Success(listings);
        }

        public async Task<RequestResult> ChangeListingStatus(int id, bool status)
        {
            var entity = await _context.Set<Listing>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity is not null)
            {
                entity.IsActive = status;
                await _listingRepository.SaveChangesAsync();
                return RequestResult.Success();
            }
            return RequestResult.Failure(Error.ErrorUnknown);
        }


    }

    public static class ListingExtensions
    {
        public static IQueryable<Listing> SortListings(this IQueryable<Listing> listings,
            SortingMethods sortingMethod)
        {
            if (sortingMethod == SortingMethods.ByPriceAsc)
            {
                return listings.OrderBy(x => x.Price);
            }

            if (sortingMethod is SortingMethods.ByPriceDesc)
            {
                return listings.OrderByDescending(x => x.Price);
            }

            if (sortingMethod is SortingMethods.ByAdditionDate)
            {
                return listings.OrderBy(x => x.DateOfCreation);
            }
            if (sortingMethod is SortingMethods.ByAdditionDateDesc)
            {
                return listings.OrderByDescending(x => x.DateOfCreation);
            }
            return listings;
        }
    }

    public enum SortingMethods
    {
        ByPriceAsc = 1,
        ByPriceDesc = 2,
        ByAdditionDate = 3,
        ByAdditionDateDesc = 4
    }
}
