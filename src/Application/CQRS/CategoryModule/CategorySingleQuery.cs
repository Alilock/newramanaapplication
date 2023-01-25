using System;
using Application.DbContext;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CategoryModule
{
	public class CategorySingleQuery :IRequest<Response<Category>>
	{
        public int Id { get; set; }
        public class CategorySingleQueryHandler : IRequestHandler<CategorySingleQuery, Response<Category>>
        {
            private readonly AppDbContext db;

            public CategorySingleQueryHandler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Response<Category>> Handle(CategorySingleQuery request, CancellationToken cancellationToken)
            {
                var data =await db.Categories.Where(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                var response = new Response<Category>();
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


