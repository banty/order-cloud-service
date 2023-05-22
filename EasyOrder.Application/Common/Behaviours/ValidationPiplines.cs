using System;
using EasyOrder.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
namespace EasyOrder.Application.Common.Behaviours
{
	public class ValidationPiplines<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest: notnull
	{
		public ValidationPiplines(IEnumerable<IValidator<TRequest>> validators)
		{
            Validators = validators;
        }

		private readonly IEnumerable<IValidator<TRequest>> Validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

			if (Validators.Any())
			{
				var validationResults = await Task.WhenAll( Validators.Select(v=>v.ValidateAsync(new ValidationContext<TRequest>(request),cancellationToken)));
				var faliures = validationResults.Where(t => !t.IsValid)
					.SelectMany(t => t.Errors)
					.Distinct()
					.ToList();
				if (faliures.Any())
				{
					
					throw new ValidationExceptions(faliures);
				}
			}
			return await next();
        }
    }
}

