using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Enums;
using Lepus.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<List<Transaction>> Select(string userName, int year, int month, TransactionType transactionType);
    }
}
