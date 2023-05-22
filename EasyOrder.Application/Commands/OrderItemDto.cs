using System;
namespace EasyOrder.Application.Commands
{
	public class OrderItemDto
	{
		public OrderItemDto()
		{
		}

        public string SKU { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal Price { get; internal set; }
    }
}

