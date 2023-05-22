using System;
using EasyOrder.Domain.Common;

namespace EasyOrder.Domain.Events
{
	public class OrderItemModifiedDomainEvent:EventBase
	{
		public OrderItemModifiedDomainEvent(EntityBase entity)
		{
            Entity = entity;
        }

        public EntityBase Entity { get; }
    }
}

