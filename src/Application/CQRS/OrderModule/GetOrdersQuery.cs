using System;
using Application.DbContext;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderModule
{
	public class GetOrdersQuery :IRequest<ICollection<Order>>
	{
        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ICollection<Order>>
        {
            private readonly AppDbContext db;

            public GetOrdersQueryHandler(AppDbContext db)
            {
                this.db = db;
            }
            public async Task<ICollection<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Orders.Where(o => o.DeletedDate == null).Include(o=>o.OrderItems).ToListAsync();
                return data;
            }
        }
    }
}

