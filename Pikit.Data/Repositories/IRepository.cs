using System;
using System.Collections.Generic;

namespace Pikit.Data.Repositories
{
	public interface IRepository<TEntity, in TKey>
		: IDisposable
	{
		// Create
		TEntity Insert(TEntity entity);

		// Read
		TEntity Get(TKey id);

		IEnumerable<TEntity> GetAll();

		// Update
		TEntity Update(TEntity entity);

		// Delete
		void Delete(TEntity entity);

		// Save
		void SaveChanges();
	}
}