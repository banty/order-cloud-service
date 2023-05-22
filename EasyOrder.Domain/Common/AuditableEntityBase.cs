using System;
namespace EasyOrder.Domain.Common
{
	public abstract class AuditableEntityBase : EntityBase
	{
		public DateTime? Created { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string? ModifiedBy { get; set; }

	}
}

