

using CarDealer.Domain.Entities;

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
                    Type = "Automatic"
                }
            };
        }
    }
}
