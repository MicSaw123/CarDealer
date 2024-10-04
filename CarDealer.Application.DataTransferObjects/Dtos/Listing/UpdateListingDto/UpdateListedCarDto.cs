using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto
{
    public class UpdateListedCarDto : BaseEntity
    {
        public string LicensePlate { get; set; }

        public int PreviousOwners { get; set; }

        public int CarConditionId { get; set; }

        public int Mileage { get; set; }

        public int CarColorId { get; set; }

        public UpdateListedCarSpecificationDto ListedCarSpecification { get; set; }
    }
}
