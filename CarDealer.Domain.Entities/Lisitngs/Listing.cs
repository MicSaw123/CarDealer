using CarDealer.Domain.Entities.Base;
using CarDealer.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain.Entities.Lisitngs
{
    public class Listing : BaseEntity
    {
        public CarDealerUser Seller { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]

        public bool IsActive { get; set; }

        [Required]

        public string Title { get; set; } = string.Empty;

        [Required]

        public string Description { get; set; } = string.Empty;

        [Required]

        public DateTime DateOfCreation { get; set; }

        [Required]
        public int ListedCarId { get; set; }

        public ListedCar ListedCar { get; set; }

        [Required]
        public int IdentifiedVehiclesId { get; set; }

        public IdentifiedVehicles IdentifiedVehicles { get; set; }
    }
}
