using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class Engine : BaseEntity
    {
        [Required]

        public string Name { get; set; } = string.Empty;

        [Required]

        public int Cylinders { get; set; }

        [Required]

        public int Displacement { get; set; }

        [Required]

        public int Horsepower { get; set; }

        [Required]

        public int Torque { get; set; }

        [Required]

        public int FuelTypeId { get; set; }

        [Required]
        public FuelType FuelType { get; set; }
    }
}
