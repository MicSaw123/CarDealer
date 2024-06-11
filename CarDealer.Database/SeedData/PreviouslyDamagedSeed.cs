using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class PreviouslyDamagedSeed
    {
        public List<PreviouslyDamaged> GetPreviouslyDamaged()
        {
            return new List<PreviouslyDamaged>
            {
                new PreviouslyDamaged
                {
                    Id = 1,
                    Name = "No"
                },
                new PreviouslyDamaged
                {
                    Id = 2,
                    Name = "Yes"
                }
            };
        }
    }
}
