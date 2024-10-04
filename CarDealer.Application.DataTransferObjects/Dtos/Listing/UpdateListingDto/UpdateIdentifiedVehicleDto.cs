using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.UpdateListingDto
{
    public class UpdateIdentifiedVehicleDto : BaseEntity
    {
        public string Vin { get; set; }

        public string ProductionDate { get; set; }

        public string FirstRegistrationDate { get; set; }

        public int CountryOfOriginId { get; set; }

        public int PreviouslyDamagedId { get; set; }
    }
}
