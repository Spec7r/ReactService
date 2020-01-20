using ReactService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactService.Interfaces
{
	public interface IRepository
	{
		Task<T> Add<T>(T entity) where T : class;

		Task<T> Delete<T>(int id) where T : class;

		Task<T> Get<T>(Guid id) where T : class;

		Task<IList<T>> GetAll<T>() where T : class;

		Task<T> Update<T>(T entity) where T : class;
	}
}
