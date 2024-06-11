namespace CarDealer.Application.Interfaces.Services.Identity
{
    public interface ITokenManagerService
    {
        Task<bool> IsCurrentTokenActive();

        Task DeactivateCurrentTokenAsync();

        Task<bool> IsActiveAsync(string token);

        Task DeactivateTokenAsync(string token);
    }
}
