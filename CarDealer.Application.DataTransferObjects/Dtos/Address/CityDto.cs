using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Address
{
    public class CityDto : BaseEntity
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public int CountryId { get; set; }

        public CountryDto Country { get; set; }
    }
}
