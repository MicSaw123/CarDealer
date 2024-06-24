using CarDealer.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto
{
    public class AddListingDto : BaseEntity
    {
        public int SellerId { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public AddIdentifiedVehiclesDto IdentifiedVehicles { get; set; }

        public AddListedCarDto ListedCar { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
