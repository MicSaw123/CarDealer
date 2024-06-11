using CarDealer.Application.Interfaces.Repositories.Generic;
using CarDealer.Domain.Entities.Address;

namespace CarDealer.Application.Interfaces.Repositories.Address
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
    }
}
