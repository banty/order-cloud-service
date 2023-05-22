using System;
using EasyOrder.Domain.Common;

namespace EasyOrder.Domain.Events
{
	public class OrderCreatedDomainEvent:EventBase
	{
		public OrderCreatedDomainEvent(EntityBase entity)
		{
            Entity = entity;
        }

        public EntityBase Entity { get; }
    }
}

