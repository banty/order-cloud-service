using System;
using AutoMapper;
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
        private readonly IMapper mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IDateTime dateTime,IMapper mapper)
		{
            this.orderRepository = orderRepository;
            this.dateTime = dateTime;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new InvalidRequest();
            var order = new Order();
            order.Customer = request.Customer;
            order.OrderDate = dateTime.Now;
            foreach(var itm in request.Items)
            {
                order.OrderItems.Add(new OrderItem {
                    Price = itm.Price,
                    Quantity = itm.Quantity,
                    SKU = itm.SKU
                });
            }

           await orderRepository.AddOrder(order);
          await  orderRepository.UnitOfWork.SaveEntityChangesAsync(cancellationToken);

           var orderDto= mapper.Map<OrderDto>(order);

            return orderDto;
            
        }
    }
}

