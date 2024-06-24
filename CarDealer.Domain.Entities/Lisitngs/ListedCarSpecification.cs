using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class ListedCarSpecification : BaseEntity
    {
        [Required]

        public int CarTypeId { get; set; }

        public CarType CarType { get; set; }

        [Required]
        public int DoorQuantityId { get; set; }

        public DoorQuantity DoorQuantity { get; set; }

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
