using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities
{
    public class CarSpecification
    {
        public int Id { get; set; }

        [Required]

        public int EngineId { get; set; }

        [Required]

        public Engine Engine { get; set; }

        [Required]

        public int TransmissionId { get; set; }

        [Required]

        public Transmission Transmission { get; set; }
    }
}
