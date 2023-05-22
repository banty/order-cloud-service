using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace EasyOrder.Application.Common.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public Dictionary<string, string[]> Errors { get;}
        public ValidationExceptions(List<ValidationFailure> failures)
		{
            var errors = failures.GroupBy(t => t.PropertyName).Select(k => new
            {
                PropertyName = k.Key,
                Errors = k.Select(t => t.ErrorMessage).ToArray()
            }).ToDictionary(x => x.PropertyName, x => x.Errors);

            Errors = errors;
        }
	}
}

