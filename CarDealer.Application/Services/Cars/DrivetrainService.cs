using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class DrivetrainService : IDrivetrainService
    {
        private readonly IDrivetrainRepository _drivetrainRepository;

        public DrivetrainService(IDrivetrainRepository drivetrainRepository)
        {
            _drivetrainRepository = drivetrainRepository;
        }

        public async Task<RequestResult<Drivetrain>> GetDrivetrainById(int drivetrainId)
        {
            var result = await _drivetrainRepository.GetByIdAsync(drivetrainId);
            if (result is null)
            {
                return RequestResult<Drivetrain>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<Drivetrain>.Success(result);
        }

        public async Task<RequestResult<IEnumerable<Drivetrain>>> GetDrivetrains()
        {
            var result = await _drivetrainRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<Drivetrain>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<Drivetrain>>.Success(result);
        }
    }
}
