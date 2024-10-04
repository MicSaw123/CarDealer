using CarDealer.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Identity
{
    public class AccountType : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
