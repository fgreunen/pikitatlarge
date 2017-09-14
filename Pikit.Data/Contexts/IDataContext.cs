using System;

namespace Pikit.Data.Contexts
{
	public interface IDataContext
		: IDisposable
	{
		int SaveChanges();
	}
}