using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOrder.Domain
{
	public static class ConfigService
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			services.AddMediatR(t => t.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
			return services;
		}
	}
}

