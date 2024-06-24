using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class PreviouslyDamagedDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
