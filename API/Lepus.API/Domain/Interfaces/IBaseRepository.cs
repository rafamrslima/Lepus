using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Select(string id);
 
        Task Insert(T obj);

        Task Update(string id, T obj);

        Task Delete(string id);
    }
}
