using CarDealer.Domain.Entities.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Application.Interfaces.Services.Cars
{
    public interface ICarService
    {
        Task<RequestResult<IEnumerable<Car>>> GetCars();

        Task<Car> GetCarById(int id);

        Task<ActionResult<Car>> AddCar(Car car);

        Task<ActionResult<Car>> DeleteCar(int id);
    }
}
