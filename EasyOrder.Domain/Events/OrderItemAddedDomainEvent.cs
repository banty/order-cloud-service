using System;
using EasyOrder.Domain.Common;

namespace EasyOrder.Domain.Events
{
	public class OrderItemAddedDomainEvent:EventBase
	{
		public OrderItemAddedDomainEvent(EntityBase entity)
		{
            Entity = entity;
        }

        public EntityBase Entity { get; }
    }
}

