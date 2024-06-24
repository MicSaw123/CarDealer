using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Address
{
    public class CountryDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
