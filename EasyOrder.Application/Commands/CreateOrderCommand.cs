using System;
using MediatR;

namespace EasyOrder.Application.Commands
{
	public class CreateOrderCommand : IRequest<OrderDto>
	{
		public CreateOrderCommand(string? customer,string? address,List<OrderItemDto> items)
		{
            Customer = customer;
            Address = address;
            Items = items;
        }

        public string? Customer { get; }
        public string? Address { get; }
        public List<OrderItemDto> Items { get; }
    }
}

