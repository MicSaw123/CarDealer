using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Cars
{
    public class DoorQuantity : BaseEntity
    {
        [Required]
        public int Doors { get; set; }
    }
}
