using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.Services;
using CarDealer.Application.Repositories;
using CarDealer.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarSpecificationRepository, CarSpecificationRepository>();
            services.AddScoped<IGenerationRepository, GenerationRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
            services.AddScoped<ICarTypeRepository, CarTypeRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarSpecificationService, CarSpecificationService>();
            services.AddScoped<IGenerationService, GenerationService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ITransmissionService, TransmissionService>();
            services.AddScoped<IEngineService, EngineService>();
            services.AddScoped<IFuelType, FuelTypeService>();
            services.AddScoped<ICarTypeService, CarTypeService>();
        }
    }
}
