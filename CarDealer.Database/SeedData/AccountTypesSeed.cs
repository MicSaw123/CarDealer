using CarDealer.Domain.Entities.Identity;

namespace CarDealer.Database.SeedData
{
    internal class AccountTypesSeed
    {
        public List<AccountType> GetAccountTypes()
        {
            return new List<AccountType>()
            {
                new AccountType
                {
                    Id = 1,
                    Name = "Private"
                },
                new AccountType
                {
                    Id = 2,
                    Name = "Company"
                }
            };
        }
    }
}
