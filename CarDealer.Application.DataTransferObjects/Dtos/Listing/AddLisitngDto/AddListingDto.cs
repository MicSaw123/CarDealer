using CarDealer.Domain.Entities.Base;
using System.Diagnostics.CodeAnalysis;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto
{
    public class AddListingDto : BaseEntity
    {
        public int SellerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [AllowNull]
        public AddIdentifiedVehiclesDto IdentifiedVehicles { get; set; } = new AddIdentifiedVehiclesDto();

        [AllowNull]
        public AddListedCarDto ListedCar { get; set; } = new AddListedCarDto();

        [AllowNull]
        public List<byte[]> Images { get; set; } = new List<byte[]>();
    }
}
