using CarDealer.Application.DataTransferObjects.Dtos.GetBasicProperties;
using CarDealer.Application.Interfaces.Services.Address;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Application.Interfaces.Services.GetBasicProperties;

namespace CarDealer.Application.Services.GetBasicProperties
{
    public class GetBasicPropertiesService : IGetBasicPropertiesService
    {
        private readonly IFuelTypeService _fuelTypeService;
        private readonly ICarColorService _carColorService;
        private readonly ICarConditionService _carConditionService;
        private readonly ICarTypeService _carTypeService;
        private readonly ITransmissionService _transmissionService;
        private readonly IDoorQuantityService _doorQuantityService;
        private readonly IAddressService _addressService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IDrivetrainService _drivetrainService;
        private readonly IPreviouslyDamagedService _previouslyDamagedService;

        public GetBasicPropertiesService(IFuelTypeService fuelTypeService, ICarColorService carColorService,
            ICarConditionService carConditionService, ICarTypeService carTypeService, ITransmissionService transmissionService,
            IDoorQuantityService doorQuantityService, IAddressService addressService, IManufacturerService manufacturerService,
            IDrivetrainService drivetrainService, IPreviouslyDamagedService previouslyDamagedService)
        {
            _fuelTypeService = fuelTypeService;
            _carColorService = carColorService;
            _carConditionService = carConditionService;
            _carTypeService = carTypeService;
            _transmissionService = transmissionService;
            _doorQuantityService = doorQuantityService;
            _addressService = addressService;
            _manufacturerService = manufacturerService;
            _drivetrainService = drivetrainService;
            _previouslyDamagedService = previouslyDamagedService;
        }

        public async Task<RequestResult<GetBasicPropertiesDto>> GetBasicProperties()
        {
            GetBasicPropertiesDto basicPropertyDto = new GetBasicPropertiesDto();
            var fuelTypes = await _fuelTypeService.GetFuelTypeDtos();
            var carColors = await _carColorService.GetCarColors();
            var carConditions = await _carConditionService.GetCarConditions();
            var carTypes = await _carTypeService.GetCarTypes();
            var transmissions = await _transmissionService.GetTransmissions();
            var doorQuantities = await _doorQuantityService.GetDoorQuantities();
            var countries = await _addressService.GetCountries();
            var manufacturers = await _manufacturerService.GetManufacturerDtos();
            var drivetrains = await _drivetrainService.GetDrivetrains();
            var previouslyDamaged = await _previouslyDamagedService.GetPreviouslyDamaged();
            basicPropertyDto.FuelType = fuelTypes.Result;
            basicPropertyDto.DoorQuantity = doorQuantities.Result;
            basicPropertyDto.Country = countries.Result;
            basicPropertyDto.CarColor = carColors.Result;
            basicPropertyDto.CarType = carTypes.Result;
            basicPropertyDto.Transmission = transmissions.Result;
            basicPropertyDto.CarCondition = carConditions.Result;
            basicPropertyDto.Manufacturer = manufacturers.Result;
            basicPropertyDto.Drivetrain = drivetrains.Result;
            basicPropertyDto.PreviouslyDamaged = previouslyDamaged.Result;
            return RequestResult<GetBasicPropertiesDto>.Success(basicPropertyDto);
        }
    }
}
