using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Cars
{
    public class EngineDto : BaseEntity
    {
        public string Name { get; set; }

        public int Cylinders { get; set; }

        public int Displacement { get; set; }

        public int Horsepower { get; set; }

        public int Torque { get; set; }

        public int FuelTypeId { get; set; }

        public FuelTypeDto FuelType { get; set; }
    }
}
