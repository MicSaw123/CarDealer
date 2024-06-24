using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class Listing : BaseEntity
    {
        public virtual CarDealerUser Seller { get; set; }

        [Required]
        public int SellerId { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfCreation { get; set; }

        [Required]

        public int ListedCarId { get; set; }

        public ListedCar ListedCar { get; set; }

        [Required]

        public int IdentifiedVehiclesId { get; set; }

        public IdentifiedVehicles IdentifiedVehicles { get; set; }
    }
}