using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Address
{
    public class Country : BaseEntity
    {

        [Required]

        public string Name { get; set; } = string.Empty;
    }
}
