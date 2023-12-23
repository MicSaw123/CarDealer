using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class Transmission
    {
        public int Id { get; set; }

        [Required]

        public string Type { get; set; }
    }
}
