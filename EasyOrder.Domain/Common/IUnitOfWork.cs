using System;
namespace EasyOrder.Domain.Common
{
	public interface IUnitOfWork
	{
		Task SaveChangesAsync(CancellationToken cancellation = default);
		Task SaveEntityChangesAsync(CancellationToken cancellation = default);
	}
}

