using System;
using Application.DbContext;
using Domain.Responses;
using MediatR;

namespace Application.CQRS.ProductModule
{
	public class ProductDeleteCommand :IRequest<Response<int>>
	{
		public int Id { get; set; }

        public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Response<int>>
        {
            private readonly AppDbContext db;

            public ProductDeleteCommandHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<int>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = db.Products
                .FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);
                if (entity == null)
                {
                    return new Response<int>
                    {
                        StatusCode = 404,
                        Message = "Can't find"
                    };
                }
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new Response<int> { Message = "Silindi", StatusCode = 200 };

            }
        }
    }
}

