using System;
using EasyOrder.Domain.Common;

namespace EasyOrder.Domain.Events
{
	public class OrderItemRemovedDomainEvent:EventBase
	{
		public OrderItemRemovedDomainEvent(EntityBase entity)
		{
            Entity = entity;
        }

        public EntityBase Entity { get; }
    }
}

