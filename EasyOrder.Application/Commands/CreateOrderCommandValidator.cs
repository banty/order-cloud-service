using System;
using FluentValidation;
namespace EasyOrder.Application.Commands
{
	public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidator()
		{
			RuleFor(t => t.Customer)
				.NotNull()
				.MaximumLength(200);
			RuleFor(t => t.Address)
				.NotNull()
				.MinimumLength(500);
				
		}
	}
}

