using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Identity;
using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Domain.Entities.Identity;
using CarDealer.Domain.Errors;

namespace CarDealer.Application.Services.Identity
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public AccountTypeService(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RequestResult<List<AccountTypeDto>>> GetAccountTypes()
        {
            var entities = _context.Set<AccountType>().ToList();
            var accountTypes = _mapper.Map<List<AccountTypeDto>>(entities);
            if (accountTypes is null)
            {
                return RequestResult<List<AccountTypeDto>>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<List<AccountTypeDto>>.Success(accountTypes);
        }
    }
}
