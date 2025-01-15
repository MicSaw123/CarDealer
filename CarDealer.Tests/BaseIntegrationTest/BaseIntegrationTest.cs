using CarDealer.Application.Interfaces.Database;
using CarDealer.Database.Context;
using CarDealer.IntegrationTests;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.IntergrationTests.BaseIntegrationTest
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        protected readonly IDbContext _context;
        private readonly IServiceScope _scope;
        protected readonly HttpClient _httpClient;
        private readonly Func<Task> _resetDatabase;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory unitTestWebAppFactory)
        {
            _scope = unitTestWebAppFactory.Services.CreateScope();
            _httpClient = unitTestWebAppFactory.CreateClient();
            _context = _scope.ServiceProvider.GetRequiredService<CarDealerContext>();
            _resetDatabase = unitTestWebAppFactory.ResetDatabaseAsync;
        }

        public async Task InitializeAsync()
        {
            await _resetDatabase();
        }

        public async Task DisposeAsync()
        {
            await _resetDatabase();
            _scope.Dispose();
            _context.Dispose();
        }
    }
}
