using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Domain.Interfaces
{
    interface IIncomesRepository
    {
        Task<List<Income>> Select(string userName, int year, int month);
    }
}
