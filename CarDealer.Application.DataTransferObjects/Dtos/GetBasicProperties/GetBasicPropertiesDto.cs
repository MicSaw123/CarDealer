using CarDealer.Application.DataTransferObjects.Dtos.Address;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.DataTransferObjects.Dtos.GetBasicProperties
{
    public class GetBasicPropertiesDto
    {
        public IEnumerable<CountryDto> Country { get; set; }

        public IEnumerable<CarColorDto> CarColor { get; set; }

        public IEnumerable<CarTypeDto> CarType { get; set; }

        public IEnumerable<FuelTypeDto> FuelType { get; set; }

        public IEnumerable<DoorQuantityDto> DoorQuantity { get; set; }

        public IEnumerable<TransmissionDto> Transmission { get; set; }

        public IEnumerable<CarConditionDto> CarCondition { get; set; }

        public IEnumerable<ManufacturerDto> Manufacturer { get; set; }

        public IEnumerable<PreviouslyDamagedDto> PreviouslyDamaged { get; set; }

        public IEnumerable<DrivetrainDto> Drivetrain { get; set; }
    }
}
