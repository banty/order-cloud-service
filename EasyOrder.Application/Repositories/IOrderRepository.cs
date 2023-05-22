using System;
using EasyOrder.Application.Commands;
using EasyOrder.Domain.Common;
using EasyOrder.Domain.Model;

namespace EasyOrder.Application.Repositories
{
	public interface IOrderRepository:IRepository
	{
		Task AddOrder(Order order);
		Task UpdateOrder(Order order);
		Task DeleteOrder(int orderId);
	}
}

