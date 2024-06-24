using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto
{
    public class GetListingsDto : BaseEntity
    {
        public int SellerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int IdentifiedVehiclesId { get; set; }

        public int ListedCarId { get; set; }

        public GetIdentifiedVehiclesDto IdentifiedVehicles { get; set; }

        public GetListedCarsDto ListedCar { get; set; }

        public List<byte[]> Images { get; set; }
    }
}
