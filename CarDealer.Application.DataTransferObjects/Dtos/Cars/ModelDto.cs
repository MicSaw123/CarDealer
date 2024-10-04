using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class ModelDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int ManufacturerId { get; set; }

        public ManufacturerDto Manufacturer { get; set; } = new ManufacturerDto();
    }
}
