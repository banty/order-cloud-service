using System;
using EasyOrder.Application.Abstract;
using EasyOrder.Application.Common.Exceptions;
using EasyOrder.Application.Repositories;
using EasyOrder.Domain.Model;
using MediatR;

namespace EasyOrder.Application.Commands
{
	public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,OrderDto>
	{
        private readonly IOrderRepository orderRepository;
        private readonly IDateTime dateTime;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IDateTime dateTime)
		{
            this.orderRepository = orderRepository;
            this.dateTime = dateTime;
        }

        public Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new InvalidRequest();
            var order = new Order();
            order.Customer = request.Customer;
            order.OrderDate = dateTime.Now;
            foreach(var itm in request.Items)
            {
                order.Items.Add(new OrderItem {
                    Price = itm.Price,
                    Quantity = itm.Quantity,
                    SKU = itm.SKU
                });
            }

            orderRepository.AddOrder(order);
            orderRepository.UnitOfWork.SaveEntityChangesAsync(cancellationToken);


            
        }
    }
}

