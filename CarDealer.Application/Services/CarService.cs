﻿using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CarDealer.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<ActionResult<Car>> AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Car>> DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> GetCarById(int carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            return car;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            List<Expression<Func<Car, object>>> includes = new();
            includes.Add(x => x.CarType);
            includes.Add(x => x.CarSpecification);
            includes.Add(x => x.Generation);
            includes.Add(x => x.Generation.Model);
            includes.Add(x => x.Generation.Model.Manufacturer);
            includes.Add(x => x.CarSpecification.Transmission);
            includes.Add(x => x.CarSpecification.Engine);
            includes.Add(x => x.CarSpecification.Engine.FuelType);
            return await _carRepository.GetAllAsync(includes);
        }
    }
}