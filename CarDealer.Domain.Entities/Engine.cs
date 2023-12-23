using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class Engine
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public int Cylinders { get; set; }

        [Required]

        public int Displacement { get; set; }

        [Required]

        public int FuelTypeId { get; set; }

        [Required]
        public FuelType FuelType { get; set; }
    }
}
