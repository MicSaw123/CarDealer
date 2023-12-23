using CarDealer.Application.Interfaces.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CarDealer.Database.Context;

namespace CarDealer.Database
{
    public static class Registration
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarDealerContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarDealership")));
            services.AddScoped<IDbContext, CarDealerContext>();
        }
    }
}