using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    public interface IExpensesService
    {
        Task<List<Expense>> Get(string userName, int year, int month);

        Task Put(string id, Expense obj);
    }
}
