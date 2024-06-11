using CarDealer.Domain.Entities.Base;

namespace CarDealer.Domain.Entities.Cars
{
    public class CarCondition : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
