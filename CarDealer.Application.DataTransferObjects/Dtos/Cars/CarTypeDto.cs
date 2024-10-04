using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class CarTypeDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
