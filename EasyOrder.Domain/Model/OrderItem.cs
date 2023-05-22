using System;
namespace EasyOrder.Domain.Model
{
	public class OrderItem
	{
		public int Id { get; set; }
		public string SKU { get; set; } = default!;
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public virtual Order Order { get; set; } = default!;

	}
}

