using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class ListedCar : BaseEntity
    {

        [Required]
        public string LicensePlate { get; set; } = string.Empty;

        [NotMapped]
        public CarColor CarColor { get; set; }

        [Required]
        public int CarColorId { get; set; }

        [Required]
        public int PreviousOwners { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int ConditionId { get; set; }

        [NotMapped]
        public CarCondition CarCondition { get; set; }

        [Required]
        public int ListedCarSpecificationId { get; set; }

        [NotMapped]
        public ListedCarSpecification ListedCarSpecification { get; set; }

    }
}
