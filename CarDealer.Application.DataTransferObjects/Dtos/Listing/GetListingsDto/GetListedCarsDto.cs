using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto
{
    public class GetListedCarsDto : BaseEntity
    {
        public string LicensePlate { get; set; }

        public int PreviousOwners { get; set; }

        public int CarConditionId { get; set; }

        public int Mileage { get; set; }

        public int CarColorId { get; set; }

        public int ListedCarSpecificationId { get; set; }

        public CarColorDto CarColor { get; set; }

        public CarConditionDto CarCondition { get; set; }

        public GetListedCarSpecificationsDto ListedCarSpecification { get; set; }
    }
}
