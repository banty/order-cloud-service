using System;
namespace EasyOrder.Application.Abstract
{
	public class DateTimeService:IDateTime
	{


		public DateTime Now => DateTime.Now;
    }
}

