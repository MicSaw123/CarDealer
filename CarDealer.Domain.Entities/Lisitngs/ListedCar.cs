using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class ListedCar : BaseEntity
    {
        [Required]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        public int CarColorId { get; set; }

        [Required]
        public int PreviousOwners { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int CarConditionId { get; set; }

        [Required]
        public int ListedCarSpecificationId { get; set; }

        public CarCondition CarCondition { get; set; }

        public CarColor CarColor { get; set; }

        public ListedCarSpecification ListedCarSpecification { get; set; }

    }
}
