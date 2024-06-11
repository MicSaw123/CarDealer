using CarDealer.Domain.Entities.Address;
using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class IdentifiedVehicles : BaseEntity
    {
        [Required]
        public string Vin { get; set; } = string.Empty;

        [Required]
        public string ProductionDate { get; set; } = string.Empty;

        [Required]
        public string FirstRegistrationDate { get; set; } = string.Empty;

        [NotMapped]
        public Country CountryOfOrigin { get; set; }

        [Required]
        public int CountryOfOriginId { get; set; }

        [Required]

        public int PreviouslyDamagedId { get; set; }

        [NotMapped]
        public PreviouslyDamaged PreviouslyDamaged { get; set; }
    }
}
