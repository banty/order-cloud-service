using System;
using EasyOrder.Application.Commands;
using EasyOrder.Domain.Common;
using EasyOrder.Domain.Model;

namespace EasyOrder.Application.Repositories
{
	public interface IOrderRepository:IRepository<Order>
	{
		Task AddOrder(Order order);
		Task UpdateOrder(Order order);
		Task DeleteOrder(int orderId);
	}
}

