﻿using CarDealer.Application.Interfaces.Repositories.Address;
using CarDealer.Application.Interfaces.Repositories.Cars;
using CarDealer.Application.Interfaces.Repositories.Listings;
using CarDealer.Application.Interfaces.Repositories.Transaction;
using CarDealer.Application.Interfaces.Services.Address;
using CarDealer.Application.Interfaces.Services.Cars;
using CarDealer.Application.Interfaces.Services.GetBasicProperties;
using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Application.Repositories.Address;
using CarDealer.Application.Repositories.Cars;
using CarDealer.Application.Repositories.Listings;
using CarDealer.Application.Repositories.Transaction;
using CarDealer.Application.Services.Address;
using CarDealer.Application.Services.AutoMapper;
using CarDealer.Application.Services.Cars;
using CarDealer.Application.Services.GetBasicProperties;
using CarDealer.Application.Services.Identity;
using CarDealer.Application.Services.Listings;
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
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IGenerationRepository, GenerationRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
            services.AddScoped<ICarTypeRepository, CarTypeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IListedCarSpecificationRepository, ListedCarSpecificationRepository>();
            services.AddScoped<IListedCarRepository, ListedCarRepository>();
            services.AddScoped<IIdentifiedVehiclesRepository, IdentifiedVehiclesRepository>();
            services.AddScoped<IDoorQuantityRepository, DoorQuantityRepository>();
            services.AddScoped<IDrivetrainRepository, DrivetrainRepository>();
            services.AddScoped<ICarColorRepository, CarColorRepository>();
            services.AddScoped<ICarConditionRepository, CarConditonRepository>();
            services.AddScoped<IPreviouslyDamagedRepository, PreviouslyDamagedRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSingleton<ITokenManagerService, TokenManagerService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IGenerationService, GenerationService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ITransmissionService, TransmissionService>();
            services.AddScoped<IEngineService, EngineService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<ICarTypeService, CarTypeService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IIdentifiedVehiclesService, IdentifiedVehiclesService>();
            services.AddScoped<IListedCarService, ListedCarService>();
            services.AddScoped<IListedCarSpecificationService, ListedCarSpecificationService>();
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IDoorQuantityService, DoorQuantityService>();
            services.AddScoped<IDrivetrainService, DrivetrainService>();
            services.AddScoped<ICarColorService, CarColorService>();
            services.AddScoped<ICarConditionService, CarConditionService>();
            services.AddScoped<IPreviouslyDamagedService, PreviouslyDamagedService>();
            services.AddScoped<IGetBasicPropertiesService, GetBasicPropertiesService>();
        }
    }
}
