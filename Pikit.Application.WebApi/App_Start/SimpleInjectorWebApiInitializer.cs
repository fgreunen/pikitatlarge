[assembly: WebActivator.PostApplicationStartMethod(typeof(Pikit.Application.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Pikit.Application.WebApi.App_Start
{
	using System.Web.Http;
	using SimpleInjector;
	using SimpleInjector.Integration.WebApi;
	using Pikit.Data.Contexts;
	using System;
	using SimpleInjector.Advanced;
	using Repository.Pattern.UnitOfWork;
	using Pikit.Infrastructure.Services.Interfaces;
	using Pikit.Infrastructure.Services.Implementations;
	using Repository.Pattern.Ef6;
	using Repository.Pattern.DataContext;

	public static class SimpleInjectorWebApiInitializer
	{
		private class DefaultLifeStyle
			: ILifestyleSelectionBehavior
		{
			public Lifestyle SelectLifestyle(Type implementationType)
			{
				return Lifestyle.Singleton;
			}
		}

		public static void Initialize()
		{
			var container = new Container();
			container.Options.LifestyleSelectionBehavior = new DefaultLifeStyle();
			container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

			InitializeContainer(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Verify();

			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}

		private static void InitializeContainer(Container container)
		{
			container.Register<IDataContextAsync, PikitContext>();
			container.Register<IUnitOfWorkAsync, UnitOfWork>();
			container.Register<ITelemetryService, TelemetryService>();
		}
	}
}