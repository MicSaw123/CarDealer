using CarDealer.Application.DataTransferObjects.Dtos.Identity;

namespace CarDealer.Application.Interfaces.Services.Identity
{
    public interface IAccountTypeService
    {
        public Task<RequestResult<List<AccountTypeDto>>> GetAccountTypes();
    }
}
