using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Address;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.DataTransferObjects.Dtos.Identity;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.FilterListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto;
using CarDealer.Domain.Entities.Address;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Entities.Identity;
using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddIdentifiedVehiclesDto, IdentifiedVehicles>().ReverseMap();
            CreateMap<AddListedCarDto, ListedCar>().ReverseMap();
            CreateMap<AddListedCarSpecificationDto, ListedCarSpecification>().ReverseMap();
            CreateMap<AddListingDto, Listing>();

            CreateMap<IdentifiedVehicles, GetIdentifiedVehiclesDto>().ReverseMap();
            CreateMap<ListedCarSpecification, GetListedCarSpecificationsDto>().ReverseMap();
            CreateMap<ListedCar, GetListedCarDto>().ReverseMap();
            CreateMap<Listing, GetListingsDto>().ReverseMap();

            CreateMap<UpdateIdentifiedVehicleDto, IdentifiedVehicles>();
            CreateMap<UpdateListedCarSpecificationDto, ListedCarSpecification>();
            CreateMap<UpdateListedCarDto, ListedCar>();
            CreateMap<UpdateListingDto, Listing>();

            CreateMap<GetListingsDto, FilterListingsDto>().ReverseMap();

            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Generation, GenerationDto>().ReverseMap();
            CreateMap<CarType, CarTypeDto>().ReverseMap();
            CreateMap<Engine, EngineDto>().ReverseMap();
            CreateMap<Transmission, TransmissionDto>().ReverseMap();
            CreateMap<FuelType, FuelTypeDto>().ReverseMap();
            CreateMap<PreviouslyDamaged, PreviouslyDamagedDto>().ReverseMap();
            CreateMap<CarColor, CarColorDto>().ReverseMap();
            CreateMap<CarCondition, CarConditionDto>().ReverseMap();
            CreateMap<DoorQuantity, DoorQuantityDto>().ReverseMap();
            CreateMap<Drivetrain, DrivetrainDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<UserInfoDto, CarDealerUser>().ReverseMap();
            CreateMap<AccountTypeDto, AccountType>().ReverseMap();
        }
    }
}