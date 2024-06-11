using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class Model : BaseEntity
    {
        [Required]

        public string Name { get; set; } = string.Empty;

        [Required]

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
