using System;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOrder.Application
{
	public static class ConfigService
	{
		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{
			return services;
		}

	}
}

