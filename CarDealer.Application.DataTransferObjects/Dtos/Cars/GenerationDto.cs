using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class GenerationDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int ModelId { get; set; }

        public ModelDto Model { get; set; }
    }
}
