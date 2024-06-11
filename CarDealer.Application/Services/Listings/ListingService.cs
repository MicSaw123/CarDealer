using CarDealer.Application.DataTransferObjects.Dtos.Listing;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Entities.Lisitngs;
using CarDealer.Domain.Errors;
using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.Services.Listings
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IImageService _imageService;
        private readonly IIdentifiedVehiclesService _identifiedVehiclesService;
        private readonly IListedCarService _listedCarService;
        private readonly IListedCarSpecificationService _listedCarSpecificationService;

        public ListingService(IListingRepository listingRepository, IImageService imageService,
            IIdentifiedVehiclesService identifiedVehiclesService, IListedCarService listedCarService,
            IListedCarSpecificationService listedCarSpecificationService)
        {
            _listingRepository = listingRepository;
            _imageService = imageService;
            _identifiedVehiclesService = identifiedVehiclesService;
            _listedCarService = listedCarService;
            _listedCarSpecificationService = listedCarSpecificationService;
        }

        public async Task<RequestResult<IEnumerable<Listing>>> GetAllListings()
        {
            var result = await _listingRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<Listing>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Listing>>.Success(result);
        }

        public async Task<RequestResult> AddListing(ListingDto listingDto,
            List<IFormFile> images)
        {
            var identifiedVehicle = new IdentifiedVehicles()
            {
                CountryOfOriginId = listingDto.IdentifiedVehiclesDto.CountryId,
                FirstRegistrationDate = listingDto.IdentifiedVehiclesDto.FirstRegistrationDate,
                PreviouslyDamagedId = listingDto.IdentifiedVehiclesDto.PreviouslyDamagedId,
                ProductionDate = listingDto.IdentifiedVehiclesDto.ProductionDate,
                Vin = listingDto.IdentifiedVehiclesDto.Vin
            };
            await _identifiedVehiclesService.AddIdentifiedVehicle(identifiedVehicle);
            var listedCarSpecification = new ListedCarSpecification()
            {
                CarTypeId = listingDto.ListedCarDto.ListedCarSpecificationDto.CarTypeId,
                DoorQuantityId = listingDto.ListedCarDto.ListedCarSpecificationDto.DoorQuantityId,
                DrivetrainId = listingDto.ListedCarDto.ListedCarSpecificationDto.DrivetrainId,
                EngineId = listingDto.ListedCarDto.ListedCarSpecificationDto.EngineId,
                GenerationId = listingDto.ListedCarDto.ListedCarSpecificationDto.GenerationId,
                TransmissionId = listingDto.ListedCarDto.ListedCarSpecificationDto.TransmissionId
            };
            await _listedCarSpecificationService.AddListedCarSpecification(listedCarSpecification);
            var listedCar = new ListedCar()
            {
                CarColorId = listingDto.ListedCarDto.CarColorId,
                ConditionId = listingDto.ListedCarDto.ConditionId,
                LicensePlate = listingDto.ListedCarDto.LicensePlate,
                Mileage = listingDto.ListedCarDto.Mileage,
                PreviousOwners = listingDto.ListedCarDto.PreviousOwners,
                ListedCarSpecificationId = listedCarSpecification.Id
            };
            await _listedCarService.AddListedCar(listedCar);
            var listing = new Listing()
            {
                SellerId = listingDto.SellerId,
                Title = listingDto.Title,
                Description = listingDto.Description,
                IdentifiedVehiclesId = identifiedVehicle.Id,
                ListedCarId = listedCar.Id,
            };
            await _listingRepository.Add(listing);
            var result = await _listingRepository.SaveChangesAsync();
            if (!result)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _imageService.UploadImageToFTP(images, listingDto.Title + "_" + listing.Id);
            return RequestResult.Success();
        }

        public async Task<RequestResult> DeleteListing(int id)
        {
            var result = await _listingRepository.GetByIdAsync(id);
            if (result is null)
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            await _listingRepository.Delete(result);
            await _listingRepository.SaveChangesAsync();
            return RequestResult.Success();
        }
    }
}
