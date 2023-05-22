using System;
using EasyOrder.Domain.Common;

namespace EasyOrder.Domain.Model
{
	public class Order:AuditableEntityBase
	{
		public DateTime OrderDate { get; set; }
		public string? Customer { get; set; }
		public string? Status { get; set; }
		public virtual List<OrderItem> Items { get; set; } = new();
		public Order()
		{
		}
	}
}

