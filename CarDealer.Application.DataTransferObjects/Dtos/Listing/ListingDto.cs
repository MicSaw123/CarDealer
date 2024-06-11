using CarDealer.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing
{
    public class ListingDto : BaseEntity
    {
        public int SellerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IdentifiedVehiclesDto IdentifiedVehiclesDto { get; set; }

        public ListedCarDto ListedCarDto { get; set; }

        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

    }
}
