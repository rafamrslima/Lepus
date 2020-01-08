using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    interface IIncomesService
    {
        Task<List<Income>> Get(string userName, int year, int month);

        Task Put(string id, Income obj);
    }
}
