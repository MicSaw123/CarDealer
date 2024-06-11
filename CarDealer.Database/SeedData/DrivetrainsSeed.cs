using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Database.SeedData
{
    internal class DrivetrainsSeed
    {
        public List<Drivetrain> GetDrivetrains()
        {
            return new List<Drivetrain>
            {
                new Drivetrain
                {
                    Id = 1,
                    Name = "FWD"
                },
                new Drivetrain
                {
                    Id = 2,
                    Name = "RWD"
                },
                new Drivetrain
                {
                    Id = 3,
                    Name = "AWD"
                },
                new Drivetrain
                {
                    Id = 4,
                    Name = "4x4"
                },
                new Drivetrain
                {
                    Id = 5,
                    Name = "6x6"
                },
                new Drivetrain
                {
                    Id = 6,
                    Name = "Other"
                }
            };
        }
    }
}
