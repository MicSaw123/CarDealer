using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class Generation : BaseEntity
    {
        [Required]

        public string Name { get; set; } = string.Empty;

        [Required]
        public int ModelId { get; set; }

        public Model Model { get; set; }

    }
}
