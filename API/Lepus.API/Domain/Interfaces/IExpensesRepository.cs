using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    public interface IExpensesRepository
    {
        Task<List<Expense>> Select(string userName, int year, int month);
    }
}
