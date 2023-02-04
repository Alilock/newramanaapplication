using System;
using Domain.Entities.Membership;

namespace Domain.Responses
{
	public class ResponseLogin
	{
		public int StatusCode { get; set; }
		public string? Message { get; set; }
		public string? Token { get; set; }
		public AppUser? User { get; set; }
	}
}

