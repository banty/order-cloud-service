using System;
using System.Collections.Generic;
using EasyOrder.Domain.Model;

namespace EasyOrder.Domain.Common
{
	public interface IUnitOfWork
	{
		
		Task<int> SaveChangesAsync(CancellationToken cancellation = default);
		Task SaveEntityChangesAsync(CancellationToken cancellation = default);
	}
}

