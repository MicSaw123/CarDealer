using CarDealer.Domain.Entities.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IDrivetrainService
    {
        public Task<RequestResult<Drivetrain>> GetDrivetrainById(int drivetrainId);

        public Task<RequestResult<IEnumerable<Drivetrain>>> GetDrivetrains();
    }
}
