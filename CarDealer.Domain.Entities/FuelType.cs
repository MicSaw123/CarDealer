using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class FuelType
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

    }
}
