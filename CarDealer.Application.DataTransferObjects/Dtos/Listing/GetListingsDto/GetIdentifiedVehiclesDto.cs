using CarDealer.Application.DataTransferObjects.Dtos.Address;
using CarDealer.Application.DataTransferObjects.Dtos.Cars;
using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.GetListingsDto
{
    public class GetIdentifiedVehiclesDto : BaseEntity
    {
        public string Vin { get; set; }

        public string ProductionDate { get; set; }

        public string FirstRegistrationDate { get; set; }

        public int CountryId { get; set; }

        public int PreviouslyDamagedId { get; set; }

        public CountryDto CountryOfOrigin { get; set; }

        public PreviouslyDamagedDto PreviouslyDamaged { get; set; }
    }
}
