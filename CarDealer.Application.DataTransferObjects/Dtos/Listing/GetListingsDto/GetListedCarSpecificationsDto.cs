using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto
{
    public class GetListedCarSpecificationsDto : BaseEntity
    {
        public int CarTypeId { get; set; }

        public int DoorQuantityId { get; set; }

        public int GenerationId { get; set; }

        public int EngineId { get; set; }

        public int TransmissionId { get; set; }

        public int DrivetrainId { get; set; }

        public CarTypeDto CarType { get; set; } = new CarTypeDto();

        public DoorQuantityDto DoorQuantity { get; set; } = new DoorQuantityDto();

        public GenerationDto Generation { get; set; } = new GenerationDto();

        public EngineDto Engine { get; set; } = new EngineDto();

        public TransmissionDto Transmission { get; set; } = new TransmissionDto();

        public DrivetrainDto Drivetrain { get; set; } = new DrivetrainDto();
    }
}
