using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public int ManufacturerId { get; set; }

        [Required]

        public Manufacturer Manufacturer { get; set; }
    }
}
