using System;
using Domain.Entities.Base;
using Domain.Entities.Membership;

namespace Domain.Entities
{
	public class Order :BaseEntity
	{

		public ICollection<OrderItem> OrderItems { get; set; }
		public string? Address { get; set; }
		public string? PaymentMethod { get; set; }
		public int UserId { get; set; }
		public AppUser? User { get; set; }
	}
}

