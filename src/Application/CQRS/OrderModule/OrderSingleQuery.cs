using System;
using Application.DbContext;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderModule
{
    public class OrderSingleQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
        public class OrderSingleQueryHandler : IRequestHandler<OrderSingleQuery, Order?>
        {
            private readonly AppDbContext db;

            public OrderSingleQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Order?> Handle(OrderSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Orders.Where(o => o.Id == request.OrderId).FirstOrDefaultAsync();
                return data;
            }
        }
    }
}
