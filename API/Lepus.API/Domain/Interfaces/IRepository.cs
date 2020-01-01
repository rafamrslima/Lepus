using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Select(string id);

        Task<List<T>> Select(string userName, int year, int month);

        Task Insert(T obj);

        Task Update(string id, T obj);

        Task Delete(string id);
         
    }
}
