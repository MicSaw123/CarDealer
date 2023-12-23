using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Application.Interfaces.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCars();

        Task<Car> GetCarById(int id);

        Task<ActionResult<Car>> AddCar(Car car);

        Task<ActionResult<Car>> DeleteCar(int id);
    }
}
