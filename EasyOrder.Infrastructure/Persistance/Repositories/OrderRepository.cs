using System;
using EasyOrder.Application.Repositories;
using EasyOrder.Domain.Common;
using EasyOrder.Domain.Model;

namespace EasyOrder.Infrastructure.Persistance.Repositories
{
	public class OrderRepository : IOrderRepository
	{
        private readonly ApplicaitonDbContext context;

        public OrderRepository(ApplicaitonDbContext context)
		{
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public Task AddOrder(Order order)
        {
            context.Orders.Add(order);
            return Task.CompletedTask;
        }

        public Task DeleteOrder(int orderId)
        {
            var order = context.Orders.Find(orderId);
            if (order != null)
                context.Orders.Remove(order);
            return Task.CompletedTask;
        }

        public Task UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            return Task.CompletedTask;
        }
    }
}

