using System.Data;

namespace CarDealer.Application.Interfaces.Repositories.Transaction
{
    public interface ITransactionRepository
    {
        public IDbTransaction BeginTransaction();
    }
}
