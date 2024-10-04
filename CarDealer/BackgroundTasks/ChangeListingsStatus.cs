using CarDealer.Application.Interfaces.Services.Listing;

namespace CarDealer.BackgroundTasks
{
    public class ChangeListingsStatus : BackgroundService
    {
        private readonly IListingService _listingService;

        public ChangeListingsStatus(IListingService listingService)
        {
            _listingService = listingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromHours(1));
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                await _listingService.DeactivateOldListings();
            }
        }
    }
}
