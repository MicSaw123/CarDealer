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

        public CarTypeDto CarType { get; set; }

        public DoorQuantityDto DoorQuantity { get; set; }

        public GenerationDto Generation { get; set; }

        public EngineDto Engine { get; set; }

        public TransmissionDto Transmission { get; set; }

        public DrivetrainDto Drivetrain { get; set; }
    }
}
