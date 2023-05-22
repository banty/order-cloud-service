using System;
using System.Reflection;
using EasyOrder.Application.Abstract;
using EasyOrder.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace EasyOrder.Application
{
	public static class ConfigService
	{
		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{
			services.AddMediatR(t =>
			
				t.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())

			

			);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPiplines<,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddTransient<IDateTime, DateTimeService>();
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			return services;
		}

	}
}

