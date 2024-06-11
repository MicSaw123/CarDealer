using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class TransmissionsSeed
    {
        public List<Transmission> GetTransmissions()
        {
            return new List<Transmission>
            {
                new Transmission
                {
                    Id = 1,
                    Name = "Automatic"
                },
                new Transmission
                {
                    Id = 2,
                    Name = "Manual"
                }
            };
        }
    }
}
