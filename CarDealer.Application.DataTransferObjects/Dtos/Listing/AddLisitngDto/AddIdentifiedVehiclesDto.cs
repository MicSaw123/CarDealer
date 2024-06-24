using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.AddLisitngDto
{
    public class AddIdentifiedVehiclesDto : BaseEntity
    {
        public string Vin { get; set; } = string.Empty;

        public string ProductionDate { get; set; } = string.Empty;

        public string FirstRegistrationDate { get; set; } = string.Empty;

        public int CountryOfOriginId { get; set; }

        public int PreviouslyDamagedId { get; set; }

    }
}
