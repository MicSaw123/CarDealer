using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public int CarTypeId { get; set; }

        [Required]
        public CarType CarType { get; set; }

        [Required]

        public int GenerationId { get; set; }

        [Required]

        public Generation Generation { get; set; }

        [Required]

        public int CarSpecificationId { get; set; }

        [Required]

        public CarSpecification CarSpecification { get; set; }
    }
}