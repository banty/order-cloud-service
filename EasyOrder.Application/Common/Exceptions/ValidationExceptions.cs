using System;
using FluentValidation.Results;

namespace EasyOrder.Application.Common.Exceptions
{
	public class ValidationExceptions:Exception
	{
		public ValidationExceptions(Dictionary<string, string[]> errors)
		{
		}
	}
}

