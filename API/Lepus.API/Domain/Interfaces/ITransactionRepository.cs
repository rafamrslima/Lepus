using Lepus.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> Select(string userName, int year, int month);
    }
}
