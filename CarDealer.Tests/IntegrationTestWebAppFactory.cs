using CarDealer.Database.Context;
using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using System.Data.Common;
using Testcontainers.MsSql;

namespace CarDealer.IntegrationTests
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:latest")
            .WithPassword("Strong_Password123456!")
            .WithPortBinding(1433)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
            .Build();
        private Respawner _respawner = default!;
        private DbConnection _dbConnection = default!;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(s => s.ServiceType ==
                typeof(DbContextOptions<CarDealerContext>));
                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }
                services.AddDbContext<CarDealerContext>(options =>
                options.UseSqlServer(_dbContainer.GetConnectionString())
                );
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            _dbConnection = new SqlConnection(_dbContainer.GetConnectionString());
            await InitializeRespawner();

        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }

        private async Task InitializeRespawner()
        {
            await _dbConnection.OpenAsync();
            var options = new DbContextOptionsBuilder<CarDealerContext>().UseSqlServer(_dbContainer.GetConnectionString()).Options;
            var dbContext = new CarDealerContext(options);
            dbContext.Database.EnsureCreated();
            _respawner = await Respawner.CreateAsync(_dbConnection, new RespawnerOptions
            {
                SchemasToInclude = new[]
                {
                    "dbo"
                },
                DbAdapter = DbAdapter.SqlServer,
                CommandTimeout = 60
            });

        }

        public Task ResetDatabaseAsync()
        {
            return _respawner.ResetAsync(_dbConnection);
        }
    }
}
