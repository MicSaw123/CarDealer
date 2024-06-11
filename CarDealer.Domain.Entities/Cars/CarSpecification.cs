using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class CarSpecification : BaseEntity
    {

        [Required]
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        [Required]

        public int TransmissionId { get; set; }

        public Transmission Transmission { get; set; }

        [Required]
        public int DrivetrainId { get; set; }

        public Drivetrain Drivetrain { get; set; }

        [Required]

        public int GenerationId { get; set; }

        public Generation Generation { get; set; }
    }
}
