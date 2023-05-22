using System;
namespace EasyOrder.Domain.Exceptions
{
	public class DomainException:Exception
	{
		public DomainException():base("Domain exception occured")
		{
		}
		public DomainException(string message):base(message)
		{

		}

		public DomainException(string message, Exception? ex) :base(message,ex)
		{

		}
	}
}

