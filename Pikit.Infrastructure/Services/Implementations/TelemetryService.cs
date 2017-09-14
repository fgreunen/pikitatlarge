using Pikit.Domain.Entities;
using Pikit.Infrastructure.Services.Interfaces;
using Repository.Pattern.UnitOfWork;
using System.Linq;

namespace Pikit.Infrastructure.Services.Implementations
{
	public class TelemetryService
		: ServiceBase, ITelemetryService
	{
		public TelemetryService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork) { }

		public void HealthTest()
		{
			var min = _unitOfWork.Repository<User>().Queryable().Select(x => (int?)x.Id).Min(x => x);
		}
	}
}