using Lepus.API.Domain.Entities;
using Lepus.API.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace Lepus.API.Domain.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> Get(string userName, int year, int month);

        Task Put(string id, decimal value, string description);

        Task Delete(string id);

        Task Post(Transaction transaction);
    }
}
