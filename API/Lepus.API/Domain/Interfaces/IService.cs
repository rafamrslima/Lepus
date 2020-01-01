using FluentValidation;
using Lepus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.Domain.Interfaces
{
	public interface IService<T> where T : BaseEntity
	{
		Task<T> Get(string id);

		Task<List<T>> Get(string userName, int year, int month);

		Task Post<V>(T obj) where V : AbstractValidator<T>;

		Task Put<V>(string id, T obj) where V : AbstractValidator<T>;

		Task Delete(string id);
		 
	}
}
