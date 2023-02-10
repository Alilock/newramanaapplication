using System;
using Application.DbContext;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderModule
{
	public class GetOrderByUser :IRequest<List<Order>>
	{
		public int Id { get; set; }
	}
    public class GetOrderByUserHandler : IRequestHandler<GetOrderByUser, List<Order>>
    {
        private readonly AppDbContext db;

        public GetOrderByUserHandler(AppDbContext db)
        {
            this.db = db;
        }
       

        public async Task<List<Order>> Handle(GetOrderByUser request, CancellationToken cancellationToken)
        {
            var data = await db.Orders.Where(o => o.UserId == request.Id).Include(o=>o.User).Include(o=>o.OrderItems).ThenInclude(o=>o.Product).ToListAsync();
            return data;
        }
    }
}

