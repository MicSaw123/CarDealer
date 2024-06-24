using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class CarConditionDto : BaseEntity
    {
        public string Name { get; set; }
    }
}
