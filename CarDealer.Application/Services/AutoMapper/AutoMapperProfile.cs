using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Address;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto;
using CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto;
using CarDealer.Domain.Entities.Address;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Entities.Lisitngs;

namespace CarDealer.Application.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddListingDto, Listing>();
            CreateMap<AddIdentifiedVehiclesDto, IdentifiedVehicles>().ReverseMap();
            CreateMap<AddListedCarDto, ListedCar>().ReverseMap();
            CreateMap<AddListedCarSpecificationDto, ListedCarSpecification>().ReverseMap();
            CreateMap<Listing, GetListingsDto>().ReverseMap();
            CreateMap<IdentifiedVehicles, GetIdentifiedVehiclesDto>().ReverseMap();
            CreateMap<ListedCarSpecification, GetListedCarSpecificationsDto>().ReverseMap();
            CreateMap<ListedCar, GetListedCarsDto>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Model, ModelDto>();
            CreateMap<Generation, GenerationDto>();
            CreateMap<CarType, CarTypeDto>();
            CreateMap<Engine, EngineDto>();
            CreateMap<Transmission, TransmissionDto>();
            CreateMap<FuelType, FuelTypeDto>();
            CreateMap<PreviouslyDamaged, PreviouslyDamagedDto>();
            CreateMap<CarColor, CarColorDto>();
            CreateMap<CarCondition, CarConditionDto>();
            CreateMap<DoorQuantity, DoorQuantityDto>();
            CreateMap<Drivetrain, DrivetrainDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
        }
    }
}