using System;
namespace EasyOrder.Domain.Common
{
	public interface IRepository<T>
	{
		IUnitOfWork UnitOfWork { get; }
	}
}

