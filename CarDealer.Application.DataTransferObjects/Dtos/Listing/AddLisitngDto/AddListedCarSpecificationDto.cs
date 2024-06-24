using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto
{
    public class AddListedCarSpecificationDto : BaseEntity
    {
        public int CarTypeId { get; set; }

        public int DoorQuantityId { get; set; }

        public int GenerationId { get; set; }

        public int EngineId { get; set; }

        public int TransmissionId { get; set; }

        public int DrivetrainId { get; set; }
    }
}
