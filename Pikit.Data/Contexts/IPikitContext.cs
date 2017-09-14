using Pikit.Domain.Entities;
using Repository.Pattern.DataContext;
using System.Data.Entity;

namespace Pikit.Data.Contexts
{
	public interface IPikitContext
		: IDataContextAsync
	{
		IDbSet<User> User { get; set; }
		void ConnectTest();
	}
}