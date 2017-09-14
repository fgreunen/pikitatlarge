using Pikit.Domain.Entities;
using Repository.Pattern.UnitOfWork;
using System;
using System.Linq;

namespace Pikit.Infrastructure.Services.Implementations.EntityServices
{
	public class UserService
		: EntityServiceBase
	{
		public UserService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork) { }

		public User Get(int id)
		{
			return _unitOfWork.Repository<User>()
				.Queryable()
				.Single(x => x.Id == id);
		}

		public User Get(Guid uniqueIdentifier)
		{
			return _unitOfWork.Repository<User>()
				.Queryable()
				.Single(x => x.UniqueIdentifier == uniqueIdentifier);
		}
	}
}