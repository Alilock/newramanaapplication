using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ProductModule
{
    public class ProductAllQuery :IRequest<Response<ICollection<Product>>>
	{
        public class ProductAllQueryHandler : IRequestHandler<ProductAllQuery, Response<ICollection<Product>>>
        {
            private readonly AppDbContext db;

            public ProductAllQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<ICollection<Product>>> Handle(ProductAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products.Where(g=>g.DeletedDate==null).Include(p=>p.Images).Include(p=>p.Colors).Include(p=>p.Materials).ThenInclude(m=>m.Material).ToListAsync(cancellationToken);
                var response = new Response<ICollection<Product>>();

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


