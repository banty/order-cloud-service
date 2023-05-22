using System;
namespace EasyOrder.Application.Common.Exceptions
{
	public class InvalidRequest :Exception
	{
		public InvalidRequest():base("Invalid request")
		{

		}
	}
}

