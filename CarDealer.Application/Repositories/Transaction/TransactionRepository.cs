using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories.Transaction;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace CarDealer.Application.Repositories.Transaction
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly IDbContext _context;

        public TransactionRepository(IDbContext context)
        {
            _context = context;
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }
    }
}
