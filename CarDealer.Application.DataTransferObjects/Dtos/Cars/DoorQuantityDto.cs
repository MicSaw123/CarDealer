using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class DoorQuantityDto : BaseEntity
    {
        public int Doors { get; set; }
    }
}
