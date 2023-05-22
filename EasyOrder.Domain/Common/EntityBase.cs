using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyOrder.Domain.Common
{
	public abstract class EntityBase
	{
		public int Id { get; set; }

		private List<EventBase> _domainEvents=new();

		[NotMapped]
		public List<EventBase> DomainEvents => _domainEvents.ToList();


		public void AddDomainEvent(EventBase @event)
		{
			_domainEvents.Add(@event);
		}

		public void RemoveDomainEvent(EventBase @event)
		{
			_domainEvents.Remove(@event);
		}

		public void ClearDomainEvents()
		{
			_domainEvents.Clear();
		}
	}
}

