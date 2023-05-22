using System;
using EasyOrder.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EasyOrder.API.Common
{
	public class ExceptionMiddleware:IMiddleware
	{
		public ExceptionMiddleware()
		{
		}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				if(ex.GetType() == typeof(ValidationExceptions))
				{
					var valex = ex as ValidationExceptions;
					if(valex!=null)
					{

						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						context.Response.ContentType = "application/json";
						var msg = new
						{
							Detail = "Validation Error occured",
							Status = StatusCodes.Status400BadRequest,
							Title = "Validation error",
							Errors = valex.Errors

						};
					await	context.Response.WriteAsJsonAsync(msg);

                    }


				}
				else
				{
					throw new Exception("Unhandled Exception");
				}

			}
           
        }
    }
}

