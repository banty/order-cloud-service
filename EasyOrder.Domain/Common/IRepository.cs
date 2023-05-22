using System;
namespace EasyOrder.Domain.Common
{
	public interface IRepository
	{
		IUnitOfWork UnitOfWork { get; }
	}
}

