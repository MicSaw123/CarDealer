using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto
{
    public class AddListedCarDto : BaseEntity
    {
        public string LicensePlate { get; set; } = string.Empty;
        public int PreviousOwners { get; set; }

        public int CarConditionId { get; set; }

        public int Mileage { get; set; }

        public int CarColorId { get; set; }

        public AddListedCarSpecificationDto ListedCarSpecification { get; set; }
            = new AddListedCarSpecificationDto();

    }
}
