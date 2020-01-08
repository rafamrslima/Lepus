using Lepus.Domain.Entities;
using System.Threading.Tasks;

namespace Lepus.Domain.Interfaces
{
	public interface IBaseService<T> where T : BaseEntity
	{
		Task<T> Get(string id);

		Task Post(T obj);
 
		Task Delete(string id); 
	}
}
