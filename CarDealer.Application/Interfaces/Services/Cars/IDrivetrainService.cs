using CarDealer.Application.DataTransferObjects.Dtos.Cars;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface IDrivetrainService
    {
        public Task<RequestResult<IEnumerable<DrivetrainDto>>> GetDrivetrains();
    }
}
