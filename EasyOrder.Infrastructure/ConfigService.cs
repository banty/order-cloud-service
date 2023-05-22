using System;
using EasyOrder.Application.Repositories;
using EasyOrder.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EasyOrder.Infrastructure.Persistance;

namespace EasyOrder.Infrastructure
{
	public static class ConfigService
	{
		public static IServiceCollection AddInfraServices(this IServiceCollection services,IConfiguration configuration )
		{
			services.AddScoped<IOrderRepository, OrderRepository>();
		
			services.AddDbContext<ApplicaitonDbContext>(t => t.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		
			return services;
		}

	}
}

