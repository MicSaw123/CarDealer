using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class FuelType : BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
