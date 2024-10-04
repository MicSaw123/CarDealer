namespace CarDealer.Application.DataTransferObjects.Dtos.Listing.SearchListingsDto
{
    public class ListingsSearchConditions
    {
        public string KeyWords { get; set; } = string.Empty;

        public int DrivetrainId { get; set; }

        public int ManufacturerId { get; set; }

        public int ModelId { get; set; }

        public int GenerationId { get; set; }

        public int CarTypeId { get; set; }

        public int TransmissionId { get; set; }

        public int DoorQuantityId { get; set; }

        public int CarConditionId { get; set; }

        public int CarColorId { get; set; }

        public int CountryOfOriginId { get; set; }

        public int PreviouslyDamagedId { get; set; }

        public int MinHorsepower { get; set; }

        public int MaxHorsepower { get; set; }

        public int MinMileage { get; set; }

        public int MaxMileage { get; set; }

        public int MinDisplacement { get; set; }

        public int MaxDisplacement { get; set; }

        public int MinYearOfProduction { get; set; }

        public int MaxYearOfProduction { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int FuelTypeId { get; set; }
    }
}
