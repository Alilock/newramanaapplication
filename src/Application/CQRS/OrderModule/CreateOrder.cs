using System;
using Application.DbContext;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.OrderModule
{
    public class CreateOrder :IRequest<Order>
    {
        public int UserId { get; set; }
        public string Address { get; set; } = String.Empty;
        public string PaymentMethod { get; set; } = String.Empty;
        public int[]? ProductIds { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrder, Order>
    {
        private readonly AppDbContext  db;

        public CreateOrderHandler(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Order> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserId = request.UserId,
                Address = request.Address,
                PaymentMethod = request.PaymentMethod
            };

            if (request.ProductIds != null)
            {
                foreach (var id in request.ProductIds)
                {
                    order.OrderItems.Add(new OrderItem { OrderId = order.Id, ProductId = id });

                }
            }
            db.Orders.Add(order);
            await db.SaveChangesAsync(cancellationToken);

            return order;
        }
    }

}

