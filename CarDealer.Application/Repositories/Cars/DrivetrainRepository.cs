using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Repositories.Generic;
using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Repositories.Cars
{
    public class DrivetrainRepository : GenericRepository<Drivetrain>, IDrivetrainRepository
    {
        public DrivetrainRepository(IDbContext context) : base(context)
        {
        }
    }
}
