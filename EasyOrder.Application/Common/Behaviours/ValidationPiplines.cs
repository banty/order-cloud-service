using System;
using EasyOrder.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
namespace EasyOrder.Application.Common.Behaviours
{
	public class ValidationPiplines<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest: notnull
	{
		public ValidationPiplines(AbstractValidator<TRequest> validator)
		{
            Validator = validator;
        }

        public AbstractValidator<TRequest> Validator { get; }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {


				var validationResult=Validator.Validate(request);
				if(!validationResult.IsValid)
				{
				var faliures = validationResult.Errors;

				var errors = faliures.GroupBy(t => t.PropertyName).Select(k => new {
					PropertyName=k.Key,
					Errors = k.Select(t=>t.ErrorMessage).ToArray()
				}).ToDictionary(x => x.PropertyName, x => x.Errors);
				throw new ValidationExceptions(errors);
				}
			return next();
        }
    }
}

