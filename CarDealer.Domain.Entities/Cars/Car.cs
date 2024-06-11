using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class Car : BaseEntity
    {
        [Required]
        public int CarTypeId { get; set; }

        [Required]
        public CarType CarType { get; set; }

        [Required]

        public int GenerationId { get; set; }

        [Required]

        public Generation Generation { get; set; }
    }
}