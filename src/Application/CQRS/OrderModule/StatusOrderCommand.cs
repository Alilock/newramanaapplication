using System;
using Application.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderModule
{
	public class StatusOrderCommand :IRequest<string>
	{
		public string Status { get; set; } = string.Empty;
        public int Id { get; set; }
        public class StatusOrderCommandHandler : IRequestHandler<StatusOrderCommand, string>
        {
            private readonly AppDbContext db;

            public StatusOrderCommandHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<string> Handle(StatusOrderCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Orders.Where(o => o.Id == request.Id).FirstOrDefaultAsync();
                if (!String.IsNullOrEmpty(request.Status))
                {
                    data.Status = request.Status;
                }
                await db.SaveChangesAsync();

                return data.Status;



            }
        }
    }
}

