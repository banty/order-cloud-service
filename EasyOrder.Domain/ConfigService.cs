using System;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOrder.Domain
{
	public static class ConfigService
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			return services;
		}
	}
}

