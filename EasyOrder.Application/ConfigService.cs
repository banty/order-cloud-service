using System;
using System.Reflection;
using EasyOrder.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOrder.Application
{
	public static class ConfigService
	{
		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{
			services.AddMediatR(t =>
			{
				t.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

				t.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPiplines<,>));

			});
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			
			return services;
		}

	}
}

