using Pikit.Domain.Core;
using Pikit.Infrastructure.Services.Implementations.EntityServices;
using Repository.Pattern.UnitOfWork;
using System;

namespace Pikit.Infrastructure.Services.Implementations
{
	public abstract class ServiceBase
		: DisposableBase
	{
		private Lazy<UserService> _userService = null;

		protected readonly IUnitOfWorkAsync _unitOfWork = null;
		protected UserService UserService { get { return _userService.Value; } }

		public ServiceBase(IUnitOfWorkAsync unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_userService = new Lazy<UserService>(() => new UserService(_unitOfWork));
		}

		protected override void DoDispose()
		{
			try
			{
				if (_userService.IsValueCreated) _userService.Value.Dispose();
			}
			finally
			{
				base.DoDispose();
			}
		}
	}
}