namespace CarDealer.Application.DataTransferObjects.Dtos.Listing
{
    public class ListedCarDto
    {
        public string LicensePlate { get; set; } = string.Empty;

        public int PreviousOwners { get; set; }

        public int ConditionId { get; set; }

        public int Mileage { get; set; }

        public int CarColorId { get; set; }

        public ListedCarSpecificationDto ListedCarSpecificationDto { get; set; }

    }
}
