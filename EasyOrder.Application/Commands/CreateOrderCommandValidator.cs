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
				.NotEmpty()
				.MaximumLength(200);
			RuleFor(t => t.Address)
				.NotEmpty()
				.NotNull()
				.MaximumLength(500);
				
		}
	}
}

