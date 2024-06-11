namespace CarDealer.Application.DataTransferObjects.Dtos.Listing
{
    public class IdentifiedVehiclesDto
    {
        public string Vin { get; set; } = string.Empty;

        public string ProductionDate { get; set; } = string.Empty;

        public string FirstRegistrationDate { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public int PreviouslyDamagedId { get; set; }
    }
}
