using System;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ProductModule
{
	public class ProductSingleQuery:IRequest<Response<Product>>
	{
        public int Id { get; set; }

        public class ProductSingleQueryHandler : IRequestHandler<ProductSingleQuery, Response<Product>>
        {
            private readonly AppDbContext db;

            public ProductSingleQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<Product>> Handle(ProductSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products.Where(g => g.Id == request.Id).Include(p=>p.Colors).ThenInclude(c=>c.Color).Include(p=>p.Materials).ThenInclude(m=>m.Material).Include(p=>p.Images).Include(p=>p.Category).FirstOrDefaultAsync(cancellationToken);
                var response = new Response<Product>();
                if (data == null)
                {
                    response.StatusCode = 404;
                    response.Message = "NotFound";
                    return response;
                }

                response.StatusCode = 200;
                response.Message = "Ok";
                response.Data = data;
                return response;
            }
        }

    }
}

