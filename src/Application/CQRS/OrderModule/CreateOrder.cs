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
        public List<OrderItem> OrderItems { get; set; }
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
                OrderItems = request.OrderItems,
                Address = request.Address,
                PaymentMethod = request.PaymentMethod
            };

            db.Orders.Add(order);
            await db.SaveChangesAsync(cancellationToken);

            return order;
        }
    }

}

