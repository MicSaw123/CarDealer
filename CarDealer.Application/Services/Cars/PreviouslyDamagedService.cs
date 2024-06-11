using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Domain.Entities.Cars;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Cars
{
    public class PreviouslyDamagedService : IPreviouslyDamagedService
    {
        private readonly IPreviouslyDamagedRepository _previouslyDamagedRepository;

        public PreviouslyDamagedService(IPreviouslyDamagedRepository previouslyDamagedRepository)
        {
            _previouslyDamagedRepository = previouslyDamagedRepository;
        }

        public async Task<RequestResult<IEnumerable<PreviouslyDamaged>>> GetPreviouslyDamaged()
        {
            var result = await _previouslyDamagedRepository.GetAllAsync();
            if (result is null)
            {
                return RequestResult<IEnumerable<PreviouslyDamaged>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<IEnumerable<PreviouslyDamaged>>.Success(result);
        }
    }
}
