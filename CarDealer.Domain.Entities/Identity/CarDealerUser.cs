using Microsoft.AspNetCore.Identity;

namespace CarDealer.Domain.Entities.Identity
{
    public class CarDealerUser : IdentityUser<int>
    {
        public int CityId { get; set; }
        public int AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }
    }
}
