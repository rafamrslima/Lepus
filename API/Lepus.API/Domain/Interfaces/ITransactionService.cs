using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Enums;
using Lepus.API.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace Lepus.API.Domain.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> Get(string userName, int year, int month, TransactionType transactionType);

        Task Put(string id, decimal value, string description);

        Task Delete(string id);

        Task Post(TransactionDto transactionDto, TransactionType transactionType);
    }
}
