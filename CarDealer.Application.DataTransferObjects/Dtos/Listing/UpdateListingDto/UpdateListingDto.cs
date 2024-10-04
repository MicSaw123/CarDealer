using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto
{
    public class UpdateListingDto : BaseEntity
    {
        public int SellerId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public UpdateIdentifiedVehicleDto IdentifiedVehicles { get; set; }

        public UpdateListedCarDto ListedCar { get; set; }
    }
}
