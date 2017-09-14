using Pikit.Domain.Core;
using Repository.Pattern.UnitOfWork;

namespace Pikit.Infrastructure.Services.Implementations.EntityServices
{
	public abstract class EntityServiceBase
		: DisposableBase
	{
		protected readonly IUnitOfWorkAsync _unitOfWork;

		public EntityServiceBase(IUnitOfWorkAsync unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}