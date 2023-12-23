using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;

namespace CarDealer.Application.Services
{
    public class CarSpecificationService : ICarSpecificationService
    {
        private readonly ICarSpecificationRepository _carSpecificationRepository;

        public CarSpecificationService(ICarSpecificationRepository carSpecificationRepository)
        {
            _carSpecificationRepository = carSpecificationRepository;
        }

        public async Task<CarSpecification> GetCarSpecificationById(int id)
        {
            var carSpecification = await _carSpecificationRepository.GetByIdAsync(id);
            return carSpecification;
        }

        public async Task<IEnumerable<CarSpecification>> GetCarSpecifications()
        {
            return await _carSpecificationRepository.GetAllAsync();
        }
    }
}
