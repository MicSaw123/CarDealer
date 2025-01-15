using CarDealer.Domain.Entities.Cars;
using CarDealer.IntergrationTests.BaseIntegrationTest;
using FluentAssertions;

namespace CarDealer.IntegrationTests.Cars
{
    public class CarColorsService : BaseIntegrationTest
    {
        CancellationToken cancellationToken = default;
        string ENDPOINT = "https://localhost:7002/api/CarColor/";

        public CarColorsService(IntegrationTestWebAppFactory unitTestWebAppFactory) : base(unitTestWebAppFactory)
        {
        }

        [Fact]
        public async Task GetCarColors_ShouldReturnSuccess()
        {
            var carColor = new CarColor()
            {
                Name = "Test",
            };
            var entities = _context.Set<CarColor>().Add(carColor);
            _context.SaveChangesAsync(cancellationToken);
            var result = await _httpClient.GetAsync(ENDPOINT + "GetCarColors");
            result.Should().NotBeNull();
            result.Should().BeSuccessful();
        }
    }
}
