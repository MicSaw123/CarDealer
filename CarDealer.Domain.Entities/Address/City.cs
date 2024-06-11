using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Address
{
    public class City : BaseEntity
    {

        [Required]

        public string Name { get; set; } = string.Empty;

        [Required]

        public string ZipCode { get; set; } = string.Empty;

        [Required]

        public int CountryId { get; set; }

        [Required]

        public Country Country { get; set; }
    }
}
