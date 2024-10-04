using CarDealer.Domain.Entities.Cars;
using CarDealer.IntergrationTests.BaseIntegrationTest;
using FluentAssertions;

namespace CarDealer.IntegrationTests.Cars
{
    public class TransmissionsService : BaseIntegrationTest
    {
        const string ENDPOINT = "https://localhost:7002/api/Transmission/";
        CancellationToken cancellationToken = default;

        public TransmissionsService(IntegrationTestWebAppFactory unitTestWebAppFactory) :
            base(unitTestWebAppFactory)
        {
        }

        [Fact]
        public async Task GetTransmissions_ShouldReturnSuccess()
        {
            var transmission = new Transmission { Name = "Test" };
            _context.Set<Transmission>().Add(transmission);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var result = await _httpClient.GetAsync(ENDPOINT + "GetTransmissions");
            result.Content.Should().NotBeNull();
        }
    }
}
