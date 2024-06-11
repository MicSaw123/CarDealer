using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class ListedCarSpecification : BaseEntity
    {
        [Required]

        public int CarTypeId { get; set; }

        [NotMapped]
        public CarType CarType { get; set; }

        [Required]
        public int DoorQuantityId { get; set; }

        [NotMapped]
        public DoorQuantity DoorQuantity { get; set; }

        [Required]
        public int EngineId { get; set; }

        [NotMapped]
        public Engine Engine { get; set; }

        [Required]

        public int TransmissionId { get; set; }

        [NotMapped]
        public Transmission Transmission { get; set; }

        [Required]
        public int DrivetrainId { get; set; }

        [NotMapped]
        public Drivetrain Drivetrain { get; set; }

        [Required]

        public int GenerationId { get; set; }

        [NotMapped]
        public Generation Generation { get; set; }
    }
}
