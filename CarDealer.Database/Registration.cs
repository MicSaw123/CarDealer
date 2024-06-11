using CarDealer.Application.Interfaces.Database;
using CarDealer.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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