using System;
using EasyOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyOrder.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController: ControllerBase
	{
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
		{
            this.mediator = mediator;
        }
		[HttpPost]
		public async Task<OrderDto> AddOrder(CreateOrderCommand request)
		{
			return await mediator.Send(request);
		}
	}
}

