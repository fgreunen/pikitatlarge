using Pikit.Infrastructure.Services.Interfaces;
using System;
using System.Web.Http;

namespace Pikit.Application.WebApi.Controllers
{
	public class TelemetryController
	: ApiController
	{
		private readonly ITelemetryService _telemetryService;

		public TelemetryController(
			ITelemetryService telemetryService)
		{
			_telemetryService = telemetryService;
		}

		[HttpGet]
		[Route(@"Telemetry/Ping")]
		[System.Web.Mvc.OutputCache(Duration = 2, Location = System.Web.UI.OutputCacheLocation.Server)]
		public IHttpActionResult Ping()
		{
			return Ok($"{DateTime.Now} -> Everything is OK!");
		}

		[HttpGet]
		[Route(@"Telemetry/HealthTest")]
		[System.Web.Mvc.OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Server)]
		public IHttpActionResult HealthTest()
		{
			_telemetryService.HealthTest();
			return Ok($"{DateTime.Now} -> Backend services are OK!");
		}
	}
}