using System;
using EasyOrder.Domain.Common;
using EasyOrder.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyOrder.Infrastructure.Persistance
{
	public class ApplicaitonDbContext:DbContext,IUnitOfWork
	{
		public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> options):base(options)
		{

		}

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        public Task SaveEntityChangesAsync(CancellationToken cancellation = default)
        {
            return Task.CompletedTask;
        }

        
    }
}

