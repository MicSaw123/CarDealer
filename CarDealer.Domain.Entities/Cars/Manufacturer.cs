using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class Manufacturer : BaseEntity
    {
        [Required]

        public string Name { get; set; } = string.Empty;
    }
}
