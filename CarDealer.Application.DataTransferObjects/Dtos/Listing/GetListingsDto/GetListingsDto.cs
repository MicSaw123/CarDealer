using CarDealer.Application.DataTransferObjects.Dtos.Image;
using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto
{
    public class GetListingsDto : BaseEntity
    {
        public int SellerId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public bool IsActive { get; set; }

        public int IdentifiedVehiclesId { get; set; }

        public int ListedCarId { get; set; }

        public GetIdentifiedVehiclesDto IdentifiedVehicles { get; set; }

        public GetListedCarDto ListedCar { get; set; }

        public List<ImageDto> Images { get; set; }
    }
}
